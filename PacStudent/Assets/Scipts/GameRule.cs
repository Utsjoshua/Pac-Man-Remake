using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour
{
    public AudioSource Background;
    public AudioClip StartBackground;
    public AudioClip NormalBackground;
    public AudioClip ScaredBackground;
    public AudioClip DeadBackground;

    public Player PacStudent;
    public Enemy Ghost;
    //private int lives;
    //private int points;
    private bool begin = false;

    void Start()
    {
        Time.timeScale = 0.0f;
        Debug.Log("Press Any Button To Start");
    }

    void Update()
    {
        if (begin == false){
            if (Input.anyKeyDown){
                Debug.Log("Game Starting");
                begin = true;
                Time.timeScale = 1.0f;
                Background.clip = StartBackground;
                Background.Play();
                NewGame();
                Debug.Log("Q - kill player, Z - Scare Ghost");
            }
        }
        else{
            if (PacStudent.GetAlive()){
                if(!Background.isPlaying){
                    if(Ghost.IsDead() && Background.clip == ScaredBackground){
                        Background.Stop();
                        Background.clip = DeadBackground;
                    }
                    else if (Ghost.IsScared() && Background.clip == NormalBackground){
                        Background.Stop();
                        Background.clip = ScaredBackground;
                    }
                    else if (Ghost.IsNormal() && Background.clip == ScaredBackground || Ghost.IsNormal() && Background == DeadBackground){
                        Background.Stop();
                        Background.clip = NormalBackground;
                    }
                    else if (Ghost.IsNormal() && Background.clip == StartBackground){
                        Background.clip = NormalBackground;
                    }
                    Background.Play();
                }
            }
            else {
                ResetGame();
            }

        }
    }

    private void NewGame(){
        //lives = 3;
        //points = 0;
        PacStudent.Revive();
    }

    private void ResetGame(){
        begin = false;
    }
}

