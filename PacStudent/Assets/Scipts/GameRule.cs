using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip StartMusic;
    public AudioClip NormalBackground;
    public AudioClip ScaredBackground;
    public AudioClip DeadBackground;
    public AudioClip DeathSound;

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
                Audio.PlayOneShot(StartMusic, 1.0f);
                NewGame();
                Debug.Log("Q - kill player, Z - Scare Ghost");
            }
        }
        else{
            if (PacStudent.GetAlive()){
                if(!Audio.isPlaying){
                    if (Ghost.IsDead()){
                        Audio.clip = DeadBackground;
                    }
                    else if (Ghost.IsScared()){
                        Audio.clip = ScaredBackground;
                    }
                    else if (Ghost.IsNormal()){
                        Audio.clip = NormalBackground;
                    }
                Audio.Play();   
                }
            }
            else {
                Audio.clip = DeathSound;
                Audio.PlayOneShot(DeathSound, 1.0f);
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

