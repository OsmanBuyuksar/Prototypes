using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour  //script that is responsible for character movement
{
    public Rigidbody rb;
    public float moveSpeed = 1f;
    public float strafeSpeed = 1f;
    public AnimatorController anim;


    public bool moving = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void MoveCharacter(float xPos)
    {
        moving = true;
        Vector3 scale = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed);
        rb.velocity = scale;
        if (xPos < 10 && xPos > -10)
        {
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
    }

}

