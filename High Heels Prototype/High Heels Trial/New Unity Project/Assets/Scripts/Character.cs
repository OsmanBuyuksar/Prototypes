using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    /* Classes that manages character movement and heels  */
    public CharacterMovement movement;
    public HeelArrenger heels;

    public float heightAdjustTime = 0.4f;  //the time to adjust height after heel height changed

    public Transform playerPos;  //the transform that stores the wanted height 

    public bool adjustingHeight = false;
    public float adjustBTime;

    private float heightSpeed;
    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.MoveCharacter(GetInput());
        
        if (adjustingHeight)
        {
            AdjustHeight();
            if(Time.time - adjustBTime > heightAdjustTime)
            {
                adjustingHeight = false;
            }
        }

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
        playerPos.position = new Vector3(transform.position.x, playerPos.position.y, transform.position.z);
        float distCovered = (Time.time - adjustBTime) * heightSpeed;
        transform.position = Vector3.Lerp(transform.position, playerPos.position, distCovered/distance);     
    }
    public void BeginAdjustHeight()
    {
        adjustingHeight = true;
        adjustBTime = Time.time;
        distance = Vector3.Distance(playerPos.position, transform.position);
        heightSpeed = distance / heightAdjustTime;
    }
    public void SetGravity(bool enabled)
    {
        gameObject.GetComponent<Rigidbody>().useGravity = enabled;
    }
}

