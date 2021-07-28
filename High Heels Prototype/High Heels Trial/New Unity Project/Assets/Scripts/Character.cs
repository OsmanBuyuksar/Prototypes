using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    /* Classes that manages character movement and heels  */
    public CharacterMovement movement;
    public HeelArrenger heels;

    public float heightAdjustTime = 0.4f;  //the time to adjust height after heel height changed

    public bool adjustingHeight = false;
    public float adjustBTime;

    private float heightSpeed;
    private float distance;

    public float height;
    private const float floorHeight = 0.1f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {      
        if (adjustingHeight)
        {
            AdjustHeight();
            if(Time.time - adjustBTime > heightAdjustTime)
            {
                adjustingHeight = false;
                movement.rb.velocity = new Vector3(movement.rb.velocity.x, 0, movement.rb.velocity.z);
            }
        }
        movement.MoveCharacter(GetInput());

        if (Input.GetKeyDown("q"))
        {
            heels.IncreaseHeelHeight();
            heels.UpdateCharacterHeight(1);
            Debug.Log(Time.deltaTime);
        }
    }
    private float GetInput()
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

    public void AdjustHeight()
    {
        Vector3 destination = new Vector3(transform.position.x, height, transform.position.z);
        float distCovered = (Time.time - adjustBTime) * heightSpeed;
        if (distance != 0)
            transform.position = Vector3.Lerp(transform.position, destination, distCovered / distance);
        Debug.Log("calıstı");
    }
    public void BeginAdjustHeight()
    {
        adjustingHeight = true;
        adjustBTime = Time.time;
        distance = height - transform.position.y;
        heightSpeed = distance / heightAdjustTime;
    }
    public void SetGravity(bool enabled)
    {
        gameObject.GetComponent<Rigidbody>().useGravity = enabled;
    }
}

