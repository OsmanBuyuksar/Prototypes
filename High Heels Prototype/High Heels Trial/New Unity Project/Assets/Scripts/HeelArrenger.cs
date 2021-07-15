using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeelArrenger : MonoBehaviour
{
    private const string heelPackName = "HeelPack";
    private const string heelName = "heel";
    private const string obstName = "Obstacle";
    private const string stepName = "Step";
    private const float stepHeight = 1f;

    private int heelCount = 0;
    private float heelHeight = 1f;
    private bool collision = false;
    private float characterVerticalHeight = 1; 
    private float characterHorizontalHeignt = 1;


    private float cubeHeight = 1f;


    /* heel colliders */
    private Stack verticalHeelObjects = new Stack();
    private Stack leftHeelObjects = new Stack();
    private Stack rightHeelObjects = new Stack();


    private BoxCollider bCollider; //box collider that is responsible for detecting obstacle collision


    /* heel collider s parents*/
    public Transform horizontalHeels;


    /* creation points for the heel colliders*/
    public Transform creationPointL;
    public Transform creationPointR;


    /* heel model updaters*/
    public HeelModelUpdater[] modelUpdaters;

    public GameObject heel;
    public GameObject heelCollider;

    public Transform playerPos; 

    private void Awake()
    {
        bCollider = GetComponent<BoxCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q"))
        {
            IncreaseHeelHeight();
            UpdateCharacterHeight(1);
        }
    }
    public void IncreaseHeelHeight()  //increases heel height and 
    {
        heelCount += 1;     
        foreach(HeelModelUpdater updater in modelUpdaters)
        {
            updater.IncreaseHeelHeight();
        }
        UpdateCollissionArea();
    }

    public void DecreaseHeelHeight(int count) //decreases heel height by count and 
    {
        heelCount -= count; //update heel count  
        foreach(HeelModelUpdater updater in modelUpdaters)
        {
            updater.DecreaseHeelHeight(count);
        }
        UpdateCollissionArea();
    }
    public void UpdateCharacterHeight(int count)  //updates character height according to the heel quantity
    {
        playerPos.position = new Vector3(playerPos.position.x, playerPos.position.y + heelHeight*count, playerPos.position.z);  
        Debug.Log("heelcount" + heelCount);
    }

    private void UpdateCollissionArea()  //updates collision detection are according to the heel quantity
    {
        if (heelCount > 0)
        {
            bCollider.size = new Vector3(bCollider.size.x, heelCount * heelHeight, bCollider.size.z);
            bCollider.center = new Vector3(0, -characterVerticalHeight / 2 - heelCount * heelHeight / 2, 0);
        }
        else
        {
            bCollider.size = new Vector3(bCollider.size.x, heelHeight, bCollider.size.z);
            bCollider.center = new Vector3(0, -characterVerticalHeight / 2 - heelHeight / 2, 0);
        }
    }

    public void UpdateHeelOrientation(string tagName)  //updates heel orientation of both colliders and models according to the floor type (!!)FIXME needs arrangement
    {
        if (tagName.Equals("Rail"))
        {
            horizontalHeels.gameObject.SetActive(true);
            playerPos.gameObject.GetComponent<Rigidbody>().useGravity = true;  //FIXME this can cause problems later
            playerPos.position = new Vector3(playerPos.position.x, characterVerticalHeight, playerPos.position.z);
        }
        else if (tagName.Equals("Floor"))
        {
            horizontalHeels.gameObject.SetActive(false);
            playerPos.gameObject.GetComponent<Rigidbody>().useGravity = false;  //FIXME this can cause problems later
            UpdateCharacterHeight(heelCount);
        }
        else
        {

        }
    }

    private void OnTriggerExit(Collider other)  
    {
        if (other.CompareTag(obstName))
        {
            int obstacleHeight = other.GetComponent<Obstacle>().obstacleHeight;
            DecreaseHeelHeight(obstacleHeight);
            UpdateCharacterHeight(-obstacleHeight);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(heelPackName))
        {
            IncreaseHeelHeight();
            UpdateCharacterHeight(1);
            Destroy(other.gameObject);
        }
        if (other.CompareTag(stepName))
        {
            //playerPos.Translate(playerPos.position.x, playerPos.position.y + stepHeight, playerPos.position.z);
            int obstacleHeight = other.GetComponent<Obstacle>().obstacleHeight;
            DecreaseHeelHeight(obstacleHeight);
        }
    }
}
