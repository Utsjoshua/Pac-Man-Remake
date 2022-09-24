using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Animator animate;
    private string state;

    void Animation(){
        if (state == "Normal"){
            animate.SetBool("IsNormal", true);
            animate.SetBool("IsScared", false);
            animate.SetBool("Flashing", false);
            animate.SetBool("IsDead", false);
        }
        else if (state == "Scared"){
            animate.SetBool("IsScared", true);
            animate.SetBool("IsNormal", false);
            animate.SetBool("Flashing", false);
            animate.SetBool("IsDead", false);
        }
        else if (state == "Flash"){
            animate.SetBool("Flashing", true);
            animate.SetBool("IsScared", false);
        }
        else if (state == "Dead"){
            animate.SetBool("IsDead", true);
            animate.SetBool("IsScared", false);
            animate.SetBool("Flashing", false);
        }
    }

    void Normal(){
        state = "Normal";
        Debug.Log("Enemies are normal");
        Debug.Log("Q - kill player, Z - Scare Ghost");
    }

    void Scared(){
        StartCoroutine(cooldown());
        state = "Scared";
        Debug.Log("Enemies are scared");
        Debug.Log("X - kill Ghosts");
    }

    void Dead(){
        StartCoroutine(revive());
        state = "Dead";
        Debug.Log("An Enemy has been taken out");
    }

    IEnumerator cooldown(){
        while (state != "Dead"){
            yield return new WaitForSeconds(7);
            if (state == "Scared"){
                state = "Flash";
            }
            if (state == "Dead"){
                break;
            }
            yield return new WaitForSeconds(3);
            if (state == "Flash"){
                Debug.Log("Ghost cooldown finished");
                Normal();
            }
            if (state == "Dead"){
                break;
            }
        }
    }

    IEnumerator revive(){
        yield return new WaitForSeconds(20);
        Debug.Log("Ghost revived");
        Normal();
    }

    public bool IsNormal(){
        return state == "Normal";
    }

    public bool IsScared(){
        return state == "Scared";
    }

    public bool IsDead(){
        return state == "Dead";
    }

    void Start()
    {
        animate = GetComponent<Animator>();
        state = "Normal";
    }


    void Update()
    {
        Animation();
        if (Input.GetKeyDown(KeyCode.Z)){
            Scared();
        }
        if (Input.GetKeyDown(KeyCode.X) && IsScared()){
            Dead();
        }
    }
}
