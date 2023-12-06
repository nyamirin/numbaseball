using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameManager gameManager;
    public int num;
    public void onclick(){
        //Debug.Log("click");
        gameManager.Input_Number(num);
    }
}
