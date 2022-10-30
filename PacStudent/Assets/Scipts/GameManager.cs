using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public PacStudentController PacStudent;
    //public Enemy Ghost;
    //private int lives;
    //private int points;
    private bool begin = false;

    void Start()
    {
        Time.timeScale = 0.0f;
    }

    void Update()
    {
        if (begin == false){
            Debug.Log("Game Starting");
            StartCoroutine(WaitAfterIntro());
        }
        else{
            if (PacStudent.GetAlive()){
                //something
            }
            else {
                ResetGame();
            }

        }
    }

    IEnumerator WaitAfterIntro(){
        begin = true;
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1.0f;
        NewGame();
        Debug.Log("Q - kill player, Z - Scare Ghost");
    }

    private void NewGame(){
        //lives = 3;
        //points = 0;
        PacStudent.Revive();
    }

    private void ResetGame(){
        begin = false;
    }

    public bool getStart(){
        return begin;
    }
}

