using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{

    public Transform player;

    // Update is called once per frame
    private void FixedUpdate()
    {
        //moves the camera based on players movement. Would be nice to later do camera smoothing or even scripted camera sequences maybe?
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z); 
    }
}
