using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TicTacToeLogic : MonoBehaviour
{
    // Each square object
    public GameObject square00;
    public GameObject square10;
    public GameObject square20;
    public GameObject square01;
    public GameObject square11;
    public GameObject square21;
    public GameObject square02;
    public GameObject square12;
    public GameObject square22;

    public Text messText;

    // Boolean flag indicating whose turn it is
    public bool isCirclesTurn;

    // Boolean flag indicating game over
    private bool gameOver;

    // Boolean flags indicating if circle or cross
    private bool circ00;
    private bool circ10;
    private bool circ20;
    private bool circ01;
    private bool circ11;
    private bool circ21;
    private bool circ02;
    private bool circ12;
    private bool circ22;

    private bool cro00;
    private bool cro10;
    private bool cro20;
    private bool cro01;
    private bool cro11;
    private bool cro21;
    private bool cro02;
    private bool cro12;
    private bool cro22;





    // Start is called before the first frame update
    void Start()
    {
        isCirclesTurn = true;
        gameOver = false;

        circ00 = false;
        circ10 = false;
        circ20 = false;
        circ01 = false;
        circ11 = false;
        circ21 = false;
        circ02 = false;
        circ12 = false;
        circ22 = false;

        cro00 = false;
        cro10 = false;
        cro20 = false;
        cro01 = false;
        cro11 = false;
        cro21 = false;
        cro02 = false;
        cro12 = false;
        cro22 = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            //messText.gameObject.SetActive(true);
            //messText.text = square11.GetComponent<TapSquare>().mark.ToString();
            circ00 = (square00.GetComponent<TapSquare>().mark == 1);
            circ10 = (square10.GetComponent<TapSquare>().mark == 1);
            circ20 = (square20.GetComponent<TapSquare>().mark == 1);
            circ01 = (square01.GetComponent<TapSquare>().mark == 1);
            circ11 = (square11.GetComponent<TapSquare>().mark == 1);
            circ21 = (square21.GetComponent<TapSquare>().mark == 1);
            circ02 = (square02.GetComponent<TapSquare>().mark == 1);
            circ12 = (square12.GetComponent<TapSquare>().mark == 1);
            circ22 = (square22.GetComponent<TapSquare>().mark == 1);

            cro00 = (square00.GetComponent<TapSquare>().mark == 2);
            cro10 = (square10.GetComponent<TapSquare>().mark == 2);
            cro20 = (square20.GetComponent<TapSquare>().mark == 2);
            cro01 = (square01.GetComponent<TapSquare>().mark == 2);
            cro11 = (square11.GetComponent<TapSquare>().mark == 2);
            cro21 = (square21.GetComponent<TapSquare>().mark == 2);
            cro02 = (square02.GetComponent<TapSquare>().mark == 2);
            cro12 = (square12.GetComponent<TapSquare>().mark == 2);
            cro22 = (square22.GetComponent<TapSquare>().mark == 2);

            print("00 circ:" + circ00 + ", cross: " + cro00 + "\n"
            + "10 circ:" + circ10 + ", cross: " + cro10 + "\n"
            + "20 circ:" + circ20 + ", cross: " + cro20 + "\n"
            + "01 circ:" + circ01 + ", cross: " + cro01 + "\n"
            + "11 circ:" + circ11 + ", cross: " + cro11 + "\n"
            + "21 circ:" + circ21 + ", cross: " + cro21 + "\n"
            + "02 circ:" + circ02 + ", cross: " + cro02 + "\n"
            + "12 circ:" + circ12 + ", cross: " + cro12 + "\n"
            + "22 circ:" + circ22 + ", cross: " + cro22 + "\n");


            if ((circ00 || cro00) && (circ10 || cro10) && (circ20 || cro20) && (circ01 || cro01) && (circ11 || cro11) && (circ21 || cro21) && (circ02 || cro02) && (circ12 || cro12) && (circ22 || cro22))
            {
                gameOver = true;
                messText.gameObject.SetActive(true);
                messText.text = "DRAW!";

            }

            // Circle win conditions:
            // Column, Row, Diag
            if ((circ00 && circ10 && circ20) || (circ01 && circ11 && circ21) || (circ02 && circ12 && circ22)
                || (circ00 && circ01 && circ02) || (circ10 && circ11 && circ12) || (circ20 && circ21 && circ22)
                || (circ00 && circ11 && circ22) || (circ02 && circ11 && circ20))
            {
                gameOver = true;
                messText.gameObject.SetActive(true);
                messText.text = "CIRCLE WINS!";

                square00.GetComponent<TapSquare>().mark = 3;
                square10.GetComponent<TapSquare>().mark = 3;
                square20.GetComponent<TapSquare>().mark = 3;
                square01.GetComponent<TapSquare>().mark = 3;
                square11.GetComponent<TapSquare>().mark = 3;
                square21.GetComponent<TapSquare>().mark = 3;
                square02.GetComponent<TapSquare>().mark = 3;
                square12.GetComponent<TapSquare>().mark = 3;
                square22.GetComponent<TapSquare>().mark = 3;
                //square00.SetActive(false);
                //square10.SetActive(false);
                //square20.SetActive(false);
                //square01.SetActive(false);
                //square11.SetActive(false);
                //square21.SetActive(false);
                //square02.SetActive(false);
                //square12.SetActive(false);
                //square22.SetActive(false);
            }


            // Cross win conditions:
            // Column, Row, Diag
            if ((cro00 && cro10 && cro20) || (cro01 && cro11 && cro21) || (cro02 && cro12 && cro22)
                || (cro00 && cro01 && cro02) || (cro10 && cro11 && cro12) || (cro20 && cro21 && cro22)
                || (cro00 && cro11 && cro22) || (cro02 && cro11 && cro20))
            {
                gameOver = true;
                messText.gameObject.SetActive(true);
                messText.text = "CROSS WINS!";

                square00.GetComponent<TapSquare>().mark = 3;
                square10.GetComponent<TapSquare>().mark = 3;
                square20.GetComponent<TapSquare>().mark = 3;
                square01.GetComponent<TapSquare>().mark = 3;
                square11.GetComponent<TapSquare>().mark = 3;
                square21.GetComponent<TapSquare>().mark = 3;
                square02.GetComponent<TapSquare>().mark = 3;
                square12.GetComponent<TapSquare>().mark = 3;
                square22.GetComponent<TapSquare>().mark = 3;
                //square00.SetActive(false);
                //square10.SetActive(false);
                //square20.SetActive(false);
                //square01.SetActive(false);
                //square11.SetActive(false);
                //square21.SetActive(false);
                //square02.SetActive(false);
                //square12.SetActive(false);
                //square22.SetActive(false);
            }

        }
    }

    public void ResetBoard()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //isCirclesTurn = true;
        //gameOver = false;
        messText.gameObject.SetActive(false);   
        messText.text = "";
        square00.GetComponent<TapSquare>().mark = 0;
        square10.GetComponent<TapSquare>().mark = 0;
        square20.GetComponent<TapSquare>().mark = 0;
        square01.GetComponent<TapSquare>().mark = 0;
        square11.GetComponent<TapSquare>().mark = 0;
        square21.GetComponent<TapSquare>().mark = 0;
        square02.GetComponent<TapSquare>().mark = 0;
        square12.GetComponent<TapSquare>().mark = 0;
        square22.GetComponent<TapSquare>().mark = 0;
        Start();


        //square00.GetComponent<TapSquare>().circle.SetActive(false);
        //square00.GetComponent<TapSquare>().cross.SetActive(false);

        //square10.GetComponent<TapSquare>().circle.SetActive(false);
        //square10.GetComponent<TapSquare>().cross.SetActive(false);

        //square20.GetComponent<TapSquare>().circle.SetActive(false);
        //square20.GetComponent<TapSquare>().cross.SetActive(false);

        //square01.GetComponent<TapSquare>().circle.SetActive(false);
        //square01.GetComponent<TapSquare>().cross.SetActive(false);

        //square11.GetComponent<TapSquare>().circle.SetActive(false);
        //square11.GetComponent<TapSquare>().cross.SetActive(false);

        //square21.GetComponent<TapSquare>().circle.SetActive(false);
        //square21.GetComponent<TapSquare>().cross.SetActive(false);

        //square02.GetComponent<TapSquare>().circle.SetActive(false);
        //square02.GetComponent<TapSquare>().cross.SetActive(false);

        //square12.GetComponent<TapSquare>().circle.SetActive(false);
        //square12.GetComponent<TapSquare>().cross.SetActive(false);

        //square22.GetComponent<TapSquare>().circle.SetActive(false);
        //square22.GetComponent<TapSquare>().cross.SetActive(false);
        //Start();

    }

}
