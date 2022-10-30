using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
private Vector3 Movement;
    private float movementSqrMagnitude;
    public float walkSpeed = 5.0f;
    private float xAxis;
    private float yAxis;
    private bool dead = false;
    private string lastinput;
    private string currentinput;
    private float HorizontalDirection = 0.0f;
    private float VerticalDirection = 0.0f;
    Animator animator;
    public GameManager game;

    void Animation()
    {
        if (dead == true){
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsDown", false);
            animator.SetBool("IsUp", false);
            animator.SetBool("IsDead", true);
        }
        if (HorizontalDirection < 0){
            animator.SetBool("IsLeft", true);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsDown", false);
            animator.SetBool("IsUp", false);
        }
        else if (HorizontalDirection > 0){
            animator.SetBool("IsRight", true);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsDown", false);
            animator.SetBool("IsUp", false);
        }
        else if (VerticalDirection < 0){
            animator.SetBool("IsDown", true);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsUp", false);
        }
        else if (VerticalDirection > 0){
            animator.SetBool("IsUp", true);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsDown", false);
        }
        else{
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsDown", false);
            animator.SetBool("IsUp", false);
        }
    }

    public void Dead(){
        dead = true;
        Debug.Log("Player has died");
        Debug.Log("Press Any Button To Try Again");
    }

    public void Revive(){
        dead = false;
        animator.SetBool("IsDead", false);
        Debug.Log("Player is alive");
    }

    public bool GetAlive(){
        return !dead;
    }

    public float getMovementSqr(){
        return movementSqrMagnitude;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (game.getIntro()){
            if (Input.GetKeyDown(KeyCode.A)){
                Debug.Log("A");
                lastinput = "A";
                currentinput = "A";
                HorizontalDirection = -1.0f;
                VerticalDirection = 0.0f;
             }
            
            if (Input.GetKeyDown(KeyCode.D)){
                Debug.Log("D");
                lastinput = "D";
                currentinput = "D";
                HorizontalDirection = 1.0f;
                VerticalDirection = 0.0f;
            }
            
            if (Input.GetKeyDown(KeyCode.S)){
                Debug.Log("S");
                lastinput = "S";
                currentinput = "S";
                HorizontalDirection = 0.0f;
                VerticalDirection = -1.0f;
            }
           
            if (Input.GetKeyDown(KeyCode.W)){
                Debug.Log("W");
                lastinput = "W";
                currentinput = "W";
                HorizontalDirection = 0.0f;
                VerticalDirection = 1.0f;
            }

            Movement = new Vector3(HorizontalDirection, VerticalDirection, 0);
            Movement = Vector3.ClampMagnitude(Movement, 3.0f);
            movementSqrMagnitude = Movement.sqrMagnitude;

            //Vector3 move = Movement * walkSpeed * Time.deltaTime;
            //transform.Translate(move, Space.World);

            if (lastinput == "A" || lastinput == "S" || lastinput == "D" || lastinput == "W"){
                //placeholder if
            }
            else if (currentinput == "A" || currentinput == "S" || currentinput == "D" || currentinput == "W"){
                //placeholder else if
            }

            Vector3 NextPos = new Vector3(gameObject.transform.position.x + HorizontalDirection, gameObject.transform.position.y + VerticalDirection, gameObject.transform.position.z);
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, NextPos, 0.04f);

            Animation();
            if (Input.GetKeyDown(KeyCode.Q)){
                Dead();
            }
        }
    }   
}
