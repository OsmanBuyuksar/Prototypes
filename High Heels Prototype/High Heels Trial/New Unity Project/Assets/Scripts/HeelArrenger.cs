using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeelArrenger : MonoBehaviour
{
    private string heelName = "heel";
    private int heelCount = 0;
    private float heelHeight;
    private bool collision = false;
    private float characterVerticalHeight = 1;
    private float characterHorizontalHeignt = 1;


    public GameObject[] verticalHeelObjects;
    public GameObject[] horizontalHeelObjects; //note to self: u can use other types

    private BoxCollider bCollider;

    public Transform verticalHeels;
    public Transform horizontalHeels;

    public Transform creationPointL;
    public Transform creationPointR;

    public HeelModelUpdater[] modelUpdater;

    public GameObject heel;
    public GameObject heelCollider;
    public Transform creationPointV;

    private Transform playerPos;
    private void Awake()
    {
        bCollider = GetComponent<BoxCollider>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        heelHeight = heel.GetComponent<BoxCollider>().size.y;
    }
    void Start()
    {
        horizontalHeelObjects = new GameObject[20]; //note to self: u can use other types
        verticalHeelObjects = new GameObject[10];

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
        creationPointV.transform.position = new Vector3(creationPointV.position.x, creationPointV.position.y  - heelHeight, creationPointV.position.z);  //create vertical heel
        GameObject obj = Instantiate(heel, creationPointV.position, creationPointV.rotation, verticalHeels);
        verticalHeelObjects[heelCount-1] = obj;

        creationPointL.transform.position = new Vector3(creationPointL.position.x - heelHeight, creationPointL.position.y, creationPointL.position.z);  //create horizontal heel (left)
        obj = Instantiate(heelCollider, creationPointL.position, creationPointL.rotation, horizontalHeels);
        horizontalHeelObjects[(heelCount * 2) - 2] = obj;

        creationPointR.transform.position = new Vector3(creationPointR.position.x + heelHeight, creationPointR.position.y, creationPointR.position.z);  //create horizontal heel (right)
        obj = Instantiate(heelCollider, creationPointR.position, creationPointR.rotation, horizontalHeels);
        horizontalHeelObjects[(heelCount * 2) -1] = obj;

        modelUpdater[0].IncreaseHeelHeight(heelCount);
        modelUpdater[1].IncreaseHeelHeight(heelCount);
        UpdateCollissionArea();
    }

    public void DecreaseHeelHeight(GameObject heel) //decreases heel height and arranges the character height accordingly
    {
        modelUpdater[0].DecreaseHeelHeight(heelCount);
        modelUpdater[1].DecreaseHeelHeight(heelCount);

        Destroy(verticalHeelObjects[heelCount]);
        Destroy(horizontalHeelObjects[heelCount*2]);
        Destroy(horizontalHeelObjects[heelCount*2-1]);

        heelCount -= 1;      
        creationPointV.transform.position = new Vector3(creationPointV.position.x, creationPointV.position.y + heelHeight, creationPointV.position.z);
    }
    public void UpdateCharacterHeight()  //updates character height according to the heel quantity
    {
        playerPos.position = new Vector3(playerPos.position.x, heelCount*heelHeight + characterVerticalHeight + 0.1f, playerPos.position.z);  
        Debug.Log("heelcount" + heelCount);
    }

    private void UpdateCollissionArea()  //updates collision detection are according to the heel quantity
    {
        bCollider.size = new Vector3(1.1f, heelCount * heelHeight, 1.1f);
        bCollider.center = new Vector3(0, -characterVerticalHeight / 2 - heelCount * heelHeight / 2, 0);
    }

    public void UpdateHeelOrientation(string tagName)  //updates heel orientation of both colliders and models according to the floor type (!!)FIXME needs arrangement
    {
        if (tagName.Equals("Rail"))
        {
            horizontalHeels.gameObject.SetActive(true);
            verticalHeels.gameObject.SetActive(false);
            playerPos.gameObject.GetComponent<Rigidbody>().useGravity = true;  //FIXME this can cause problems later
            playerPos.position = new Vector3(playerPos.position.x, characterVerticalHeight, playerPos.position.z);
        }
        else if (tagName.Equals("Floor"))
        {
            horizontalHeels.gameObject.SetActive(false);
            verticalHeels.gameObject.SetActive(true);
            playerPos.gameObject.GetComponent<Rigidbody>().useGravity = false;  //FIXME this can cause problems later
            UpdateCharacterHeight();
        }
        else
        {

        }
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
