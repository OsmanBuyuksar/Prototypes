using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public static Rigidbody rb;
    public float moveSpeed = 1f;

    private bool moving = false;

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
        if(Input.GetAxis("Vertical") > 0)
        {
            MoveCharacter();
        }
    }

    private void MoveCharacter()
    {
        Vector3 scale = new Vector3(0,0,moveSpeed);
        rb.velocity = scale;
    }
}
