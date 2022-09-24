using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector3 Movement;
    private float movementSqrMagnitude;
    public float walkSpeed = 5.0f;
    private float xAxis;
    private float yAxis;
    private bool dead = false;

    public AudioSource sound;
    public AudioClip footstepSound;
    public AudioClip Collecting;

    Animator animator;

    void GetMovementInput()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
        Movement = new Vector3(xAxis, yAxis, 0);
        Movement = Vector3.ClampMagnitude(Movement, 3.0f);
        movementSqrMagnitude = Movement.sqrMagnitude;
        //Debug.Log("Movement = " + Movement);
    }

    void CharacterPosition()
    {
        Vector3 move = Movement * walkSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);
    }

    void Animation()
    {
        if (dead == true){
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsDown", false);
            animator.SetBool("IsUp", false);
            animator.SetBool("IsDead", true);
        }
        if (xAxis < 0){
            animator.SetBool("IsLeft", true);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsDown", false);
            animator.SetBool("IsUp", false);
        }
        else if (xAxis > 0){
            animator.SetBool("IsRight", true);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsDown", false);
            animator.SetBool("IsUp", false);
        }
        else if (yAxis < 0){
            animator.SetBool("IsDown", true);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsUp", false);
        }
        else if (yAxis > 0){
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

    void PlaySound()
    {
        if (Movement != new Vector3(0.0f, 0.0f, 0.0f)){
            sound.clip = footstepSound;
            sound.Play();
            Debug.Log("Played");
        }
    }

    void Dead(){
        //placeholder
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
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GetMovementInput();
        CharacterPosition();
        Animation();
        PlaySound();
        //placeholder
        if (Input.GetKeyDown(KeyCode.Q)){
            Dead();
        }
    }
}
