using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text text_First;
    public TMP_Text text_Second;
    public TMP_Text text_Thrid;
    public TMP_Text text_Guess;
    public TMP_Text text_Strike;
    public TMP_Text text_Ball;
    public TMP_Text text_Log;
    public TMP_Text text_Answer;
    
    public GameObject endUI;

    private int answer_First;
    private int answer_Second;
    private int answer_Third;
    
    private int guess_First = 0;
    private int guess_Second = 0;
    private int guess_Third = 0;
    private int guess_cnt = 0;

    private int cnt_Strike = 0;
    private int cnt_Ball = 0;

    private bool playing = true;

    // Start is called before the first frame update
    void Start(){
        //set answer
        answer_First = UnityEngine.Random.Range(1, 10);
        answer_Second = UnityEngine.Random.Range(1, 10);
        answer_Third = UnityEngine.Random.Range(1, 10);

        //testing
        //text_Answer.text = ""+ answer_First + answer_Second + answer_Third;
    }

    public void Input_Number(int n){
        if(!playing) return;
        //Debug.Log("input");
        switch(guess_cnt){
            case 0:
                guess_First = n;
                guess_cnt++;
                text_First.text = n + "";
                break;
            case 1:
                guess_Second = n;
                guess_cnt++;
                text_Second.text = n + "";
                break;
            case 2:
                guess_Third = n;
                guess_cnt = 0;
                text_Thrid.text = n + "";
                break;
            default:
                Debug.Log("err");
                break;
        }
    }

    public void Guess(){
        //input 3 number?
        if(guess_Third == 0){
            Debug.Log("err_input3");
            return;
        }

        cnt_Strike = 0;
        cnt_Ball = 0;

        //check first
        if(guess_First == answer_First) cnt_Strike++;
        else if(guess_First == answer_Second && guess_Second != answer_Second) cnt_Ball++;
        else if(guess_First == answer_Third && guess_Third != answer_Third) cnt_Ball++;
        //check second
        if(guess_Second == answer_Second) cnt_Strike++;
        else if(guess_Second == answer_First && guess_First != answer_First) cnt_Ball++;
        else if(guess_Second == answer_Third && guess_Third != answer_Third) cnt_Ball++;
        //check third
        if(guess_Third == answer_Third) cnt_Strike++;
        else if(guess_Third == answer_First && guess_First != answer_First) cnt_Ball++;
        else if(guess_Third == answer_Second && guess_Second != answer_Second) cnt_Ball++;

        text_Guess.text = "Guess : " + guess_First + " " + guess_Second + " " + guess_Third;
        text_Strike.text = "Strike : " + cnt_Strike;
        text_Ball.text = "Ball : " + cnt_Ball;
        Make_Log();

        //correct
        if(cnt_Strike == 3){
            playing = false;
            endUI.SetActive(true);
        }
    }

    void Make_Log(){
        text_Log.text += "\n" + guess_First + guess_Second + guess_Third + "   " + cnt_Strike + "S " + cnt_Ball + "B ";
    }

    public void Retry(){
        endUI.SetActive(false);

        answer_First = UnityEngine.Random.Range(1, 10);
        answer_Second = UnityEngine.Random.Range(1, 10);
        answer_Third = UnityEngine.Random.Range(1, 10);
        
        guess_First = 0;
        guess_Second = 0;
        guess_Third = 0;
        guess_cnt = 0;

        text_First.text = "0";
        text_Second.text = "0";
        text_Thrid.text = "0";
        text_Guess.text = "Guess : ";
        text_Strike.text = "Strike : ";
        text_Ball.text = "Ball : ";
        text_Log.text = "Log";

        playing = true;
    }
}
