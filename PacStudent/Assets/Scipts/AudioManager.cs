using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource sound;
    public AudioSource Background;
    public AudioClip[] playerSound;
    public AudioClip[] BackgroundSound;
    public GameManager Game;
    public Player PacStudent;
    public Enemy Ghost;
    
    void Start()
    {
        
    }

    void Update()
    {
        BackgoundMusic();
        PlayerSound();
    }

    public void PlayerSound(){
        if (PacStudent.getMovementSqr() > 0.25f && !sound.isPlaying){
            sound.clip = playerSound[0];
            sound.pitch = 2.0f;
            sound.volume = PacStudent.getMovementSqr();
            sound.Play();
            Background.volume = 0.5f;
        }
        else if (PacStudent.getMovementSqr() <= 0.3f && sound.isPlaying){
            sound.Stop();
            Background.volume = 1.0f;

        }
        if (PacStudent.GetAlive() == false){
            sound.clip = playerSound[2];
            sound.Play();
        }
    }

    public void BackgoundMusic(){
        if (Input.anyKey && Game.getStart() == false){
            Background.clip = BackgroundSound[0];
            Background.Play();
        }
        if(!Background.isPlaying){
            if(Ghost.IsDead() && Background.clip == BackgroundSound[2]){
                Background.Stop();
                Background.clip = BackgroundSound[3];
            }
            else if (Ghost.IsScared() && Background.clip == BackgroundSound[1]){
                Background.Stop();
                Background.clip = BackgroundSound[2];
                }
            else if (Ghost.IsNormal() && Background.clip == BackgroundSound[2] || Ghost.IsNormal() && Background == BackgroundSound[3]){
                Background.Stop();
                Background.clip = BackgroundSound[1];
            }
            else if (Ghost.IsNormal() && Background.clip == BackgroundSound[0]){
                Background.clip = BackgroundSound[1];
            }
            Background.Play();
        }
    }
}
