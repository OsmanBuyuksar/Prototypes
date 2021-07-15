﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour  //script that is responsible for character movement
{
    public static Rigidbody rb;
    public float moveSpeed = 1f;
    public float strafeSpeed = 1f;
    public AnimatorController anim;
    public Transform playerPos;
    public float heightSpeed;

    public bool moving = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        MoveCharacter(GetInput());
        AdjustHeight();
    }

    private void MoveCharacter(float xPos)
    {
        moving = true;
        Vector3 scale = new Vector3(0,0,moveSpeed);
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
    float GetInput()
    {
        Vector3 worldPosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, 1000))
        {
            worldPosition = hitData.point;
            return worldPosition.x;
        }
        else
        {
            return 0;
        }
    }

    private void AdjustHeight()
    {
        playerPos.position = new Vector3(transform.position.x, playerPos.position.y, transform.position.z);
        gameObject.transform.position = Vector3.Lerp(transform.position, playerPos.position, heightSpeed * Time.deltaTime);
    }
}
