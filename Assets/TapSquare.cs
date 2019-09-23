using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adding OnTouch3D here forces us to implement the 
// OnTouch function, but also allows us to reference this
// object through the OnTouch3D class.
public class TapSquare : MonoBehaviour, OnTouch3D
{
    //// We will set this public variable to our Space object
    //public GameObject square;
    // These will store references to our Space child objects
    public GameObject circle;
    public GameObject cross;
    // Stores a number representation of shape: 0-none, 1-circle, 2-cross
    public int mark;

    // Debouncing is a term from Electrical Engineering referring to 
    // preventing multiple presses of a button due to the physical switch
    // inside the button "bouncing".
    // In CS we use it to mean any action to prevent repeated input. 
    // Here we will simply wait a specified time before letting the button
    // be pressed again.
    // We set this to a public variable so you can easily adjust this in the
    // Unity UI.
    public float debounceTime = 0.3f;
    // Stores a counter for the current remaining wait time.
    private float remainingDebounceTime;


    void Start()
    {
        mark = 0;
        remainingDebounceTime = debounceTime;
    }

    void Update()
    {
        if (remainingDebounceTime > 0)
            remainingDebounceTime -= Time.deltaTime;
        if (mark == 0)
        {
            circle.SetActive(false);
            cross.SetActive(false);
        }
    }

    public void OnTouch()
    {
        if (remainingDebounceTime <= 0)
        {

            // Determine whose move it is
            if (mark == 0)
            {
                bool circTurn = FindObjectOfType<TicTacToeLogic>().isCirclesTurn;
                if (circTurn)
                {
                    mark = 1;
                    circle.SetActive(true);

                }
                else
                {
                    mark = 2;
                    cross.SetActive(true);
                }
                FindObjectOfType<TicTacToeLogic>().isCirclesTurn = !circTurn;
            }
            remainingDebounceTime = debounceTime;
        }
    }

}