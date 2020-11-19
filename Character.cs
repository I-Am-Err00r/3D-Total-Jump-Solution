using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Rigidbody rb;
    protected Collider col;
    protected Character character;

    [HideInInspector] 
    public bool isGrounded;
    [HideInInspector]
    public bool isJumping;
    protected Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        Initializtion();
    }

    protected virtual void Initializtion()
    {
        character = GetComponent<Character>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        anim = GetComponent<Animator>();
    }

    protected virtual bool CollisionCheck(Vector3 center, Vector3 direction, float distance, LayerMask collision)
    {
        if(Physics.BoxCast(center, new Vector3(.5f, .5f, .5f), direction, Quaternion.identity, distance, collision))
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
