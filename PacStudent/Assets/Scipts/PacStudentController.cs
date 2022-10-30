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
    Animator animator;

    void GetMovementInput()
    {
        // xAxis = Input.GetAxis("Horizontal");
        // yAxis = Input.GetAxis("Vertical");
        // Movement = new Vector3(xAxis, yAxis, 0);
        // Movement = Vector3.ClampMagnitude(Movement, 3.0f);
        // movementSqrMagnitude = Movement.sqrMagnitude;
        // //Debug.Log("Movement = " + Movement);
    }

    // void CharacterPosition()
    // {
    //     Vector3 move = Movement * walkSpeed * Time.deltaTime;
    //     transform.Translate(move, Space.World);
    // }

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
        //GetMovementInput();
        //CharacterPosition();

        if (Input.GetKeyDown(KeyCode.A)){
            Debug.Log("A");
            lastinput = "A";
            currentinput = "A";
            Movement = Vector3.Lerp(transform.position, new Vector3(transform.position.x -1, transform.position.y, transform.position.z), 0.05f);
            Vector3 move = Movement * walkSpeed * Time.deltaTime;
            transform.Translate(move, Space.World);
            //Movement = Vector3.Lerp(gameObject.transform.position, new Vector3(-1,0,0), 0.5f);
        }
            
        if (Input.GetKeyDown(KeyCode.D)){
            Debug.Log("D");
            lastinput = "D";
            currentinput = "D";
            Movement = Vector3.Lerp(transform.position, new Vector3(transform.position.x +1, transform.position.y, transform.position.z), 0.05f);
            Vector3 move = Movement * walkSpeed * Time.deltaTime;
            transform.Translate(move, Space.World);
            //Movement = Vector3.Lerp(gameObject.transform.position, new Vector3(1,0,0), 0.5f);
        }
            
        if (Input.GetKeyDown(KeyCode.S)){
            Debug.Log("S");
            lastinput = "S";
            currentinput = "S";
            Movement = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y -1, transform.position.z), 0.05f);
            Vector3 move = Movement * walkSpeed * Time.deltaTime;
            transform.Translate(move, Space.World);
            //Movement = Vector3.Lerp(gameObject.transform.position, new Vector3(0,-1,0), 0.5f);
        }
           
        if (Input.GetKeyDown(KeyCode.W)){
            Debug.Log("W");
            lastinput = "W";
            currentinput = "W";
            Movement = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y +1, transform.position.z), 0.05f);
            Vector3 move = Movement * walkSpeed * Time.deltaTime;
            transform.Translate(move, Space.World);
            //Movement = Vector3.Lerp(gameObject.transform.position, new Vector3(0,1,0), 0.5f);
        }
            
        Animation();
        if (Input.GetKeyDown(KeyCode.Q)){
            Dead();
        }
    }
}
