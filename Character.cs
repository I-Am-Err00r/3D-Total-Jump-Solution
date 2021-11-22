using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will manage different character states and scripts that inherit from the Character script can change the value as needed
public class Character : MonoBehaviour
{
    //A reference to the Rigidbody2D on the Character
    protected Rigidbody rb;
    //A reference to the Collider2D on the Character
    protected Collider col;
    //A reference to the Character script
    protected Character character;

    //Determines if the Character is grounded
    [HideInInspector]
    public bool isGrounded;
    //Determines if the Character is performing an itial jump and/or an additional jump
    [HideInInspector]
    public bool isJumping;

    //Instead of running Start() in each script, set it up this way so that each script can get all the values of Start() and add more logic for specific script that would need to at Start()
    void Start()
    {
        Initializtion();
    }

    //Virtual Start() method; every script will run this, and those that need to add more logic can override it and add more logic to it after the base.Initialization() line that pops up when overriding a virtual method
    protected virtual void Initializtion()
    {
        //Establishes the Rigidbody2D on the Character
        rb = GetComponent<Rigidbody>();
        //Establishes the Collider2D on the Character
        col = GetComponent<Collider>();
        //Establishes the Character on the Character
        character = GetComponent<Character>();
    }


    //A method that is used by child scripts of the Character to determine if the Character is touching a collider it should be aware of so those scripts can perform certain logic depending on what those scripts need to do
    protected virtual bool CollisionCheck(Vector3 center, Vector3 direction, float distance, LayerMask collision)
    {
        //Checks to see if the BoxCast method is colliding with anything that is a layer it should look out for
        if (Physics.BoxCast(center, new Vector3(.5f, .5f, .5f), direction, Quaternion.identity, distance, collision))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
