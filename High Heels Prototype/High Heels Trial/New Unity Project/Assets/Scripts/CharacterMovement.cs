using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour  //script that is responsible for character movement
{
    public static Rigidbody rb;
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
        Vector3 scale = new Vector3(0, 0, moveSpeed);
        rb.velocity = scale; //* Input.GetAxis("Vertical");  //moves character depending on the input
        if (xPos < 10 && xPos > -10)
        {
            Vector3 pos = new Vector3(xPos, transform.position.y, transform.position.z);
            rb.MovePosition(pos);
        }
        else
        {

        }
        anim.UpdateAnimationState(moving);
    }

}

