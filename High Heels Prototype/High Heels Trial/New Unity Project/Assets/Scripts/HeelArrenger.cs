using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeelArrenger : MonoBehaviour
{
    private int heelCount = 1;
    private float heelHeight;
    private bool collision = false;
    private float characterHeight = 1;

    private BoxCollider bCollider;

    public GameObject heel;
    public Transform creationPoint;

    private Transform playerPos;
    private void Awake()
    {
        bCollider = GetComponent<BoxCollider>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        heelHeight = heel.GetComponent<BoxCollider>().size.y;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q"))
        {
            IncreaseHeelHeight(); 
        }
    }
    public void IncreaseHeelHeight()  //increases heel height and arranges the character height accordingly
    {
        heelCount += 1;
        UpdateCharacterHeight();
        creationPoint.transform.position = new Vector3(creationPoint.position.x, creationPoint.position.y  - heelHeight, creationPoint.position.z);
        Instantiate(heel, creationPoint.position, creationPoint.rotation, transform);
        UpdateCollissionArea();
    }

    public void DecreaseHeelHeight(GameObject heel) //decreases heel height and arranges the character height accordingly
    {
        heelCount -= 1;
        Destroy(heel);
        creationPoint.transform.position = new Vector3(creationPoint.position.x, creationPoint.position.y + heelHeight, creationPoint.position.z);
    }
    public void UpdateCharacterHeight()  //updates character height according to the heel quantity
    {
        playerPos.position = new Vector3(playerPos.position.x, heelCount*heelHeight + characterHeight + 0.1f, playerPos.position.z);
        Debug.Log("heelcount" + heelCount);
    }

    private void UpdateCollissionArea()  //updates collision detection are according to the heel quantity
    {
        bCollider.size = new Vector3(1.1f, heelCount * heelHeight, 1.1f);
        bCollider.center = new Vector3(0, -characterHeight / 2 - heelCount * heelHeight / 2, 0);
    }

    private void OnTriggerExit(Collider other)  
    {
        if (other.CompareTag("Obstacle"))
        {
            UpdateCharacterHeight();
            UpdateCollissionArea();
        }
    }
}
