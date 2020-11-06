using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 3f;

    public Rigidbody2D rb;
    //Animator here

    public bool isSprinting;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {

        //will not run if time is paused AKA pause menu
        if (Time.timeScale == 0)
            return;



        //Gets the horizontal/vertical axis, which makes support for WASD and controller support easier i think?; 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //animator movement speed set float

        //If the player is trying to move in any direction
        if(movement.x != 0 || movement.y !=0)
        {
            //Animator set horizontal and vertical floats for animation

        }
        if (Input.GetKey(KeyCode.LeftShift))//Reads the shift key and runs if its being pressed, Keycode shift can be changed to a variable that we can use to allow button remapping easily
        {
            //set animator bool sprinting to true
            isSprinting = true;

        }
        else
        {
            //set animator bool sprinting to false
            isSprinting = false;
        }




        


}
    //will run actual movement of the player NOTE: runs every frame 
    private void FixedUpdate()
    {
        if (isSprinting)
        {
            moveSpeed = 5f;
        }
        else
        {
            moveSpeed = 3f;
        }
        //Move the player to their position plus their movement speed based on delta time
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);



    }
}
