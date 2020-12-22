using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 1.5f;

    public Rigidbody2D rb;
    public PlayerAttack pAttack;
    public PlayerStatus pStatus;
    //Animator here
    public Animator animator;
    public float dashSpeed;
    public float dashCooldown;

    public float staminaReductionRate;
    public float staminaIncreaseRate;


    public float timeStampDecrease = 0;
    public float timeStampIncrease = 0;
    public bool isSprinting;

    Vector2 movement;


    private void Start()
    {
        pAttack = GetComponent<PlayerAttack>();
        pStatus = GetComponent<PlayerStatus>();
    }



    // Update is called once per frame
    void Update()
    {

        //will not run if time is paused AKA pause menu
        if (PauseMenu.GameIsPaused)
            return;



        //Gets the horizontal/vertical axis, which makes support for WASD and controller support easier i think?; 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //animator movement speed set float

        //If the player is trying to move in any direction
        if(movement.x != 0 || movement.y !=0)
        {
            animator.SetFloat("HorizontalAxis", movement.x);
            animator.SetFloat("VerticalAxis", movement.y);
            //Animator set horizontal and vertical floats for animation

        }
        if (Input.GetKey(KeyCode.LeftShift))//Reads the shift key and runs if its being pressed, Keycode shift can be changed to a variable that we can use to allow button remapping easily
        {

            //if the player is not exausted, let player sprint
            if (!pStatus.isExhausted)
            {
                animator.SetBool("isSprinting", true);
                isSprinting = true;
                if (timeStampDecrease <= Time.time)
                {
                    timeStampDecrease = Time.time + staminaReductionRate;
                    pStatus.diminishStamina(1);//reduce stamina by 1 every <staminaReductionRate> seconds
                    
                }
                

            }
            
        }
        else
        {
            //set animator bool sprinting to false
            animator.SetBool("isSprinting", false);

            if (timeStampIncrease  <= Time.time)
            {
                timeStampIncrease = Time.time + staminaIncreaseRate;
                pStatus.regenerateStamina(1);
            }

            isSprinting = false;
        }
      
}
    //will run actual movement of the player NOTE: runs every frame 
    
    private void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (Vector2)((mousePos - transform.position));
        direction.Normalize();
        if (pAttack.isAttacking || pStatus.isExhausted)
        {
            moveSpeed = 0.2f;
        }
        else if (isSprinting)
        {
            moveSpeed = 2.5f;
        }
        else
        {
            moveSpeed = 1.5f;
        }
        //Move the player to their position plus their movement speed based on delta time
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);



    }

    





}
