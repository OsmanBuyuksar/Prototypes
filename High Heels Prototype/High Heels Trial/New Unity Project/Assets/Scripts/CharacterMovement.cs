using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

        MoveCharacter(GetInput());
    }

    private void MoveCharacter(float xPos)
    {
        Vector3 scale = new Vector3(0,0,moveSpeed);
        rb.velocity = scale * Input.GetAxis("Vertical");  //moves character depending on the input
        if (xPos < 10 && xPos > -10)
        {
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
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
}
