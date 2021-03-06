using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeelArrenger : MonoBehaviour
{
    private const string heelPackName = "HeelPack";
    private const string heelName = "heel";
    private const string obstName = "Obstacle";
    private const string stepName = "Step";
    private const string railName = "Rail";
    private const string floorName = "Floor";

    private const float stepHeight = 1f;

    private int heelCount = 0;
    private float heelHeight = 1f;
    private float characterVerticalHeight = 1; 
    private float adjustHeight = 0.3f;  //adjustment value for heel collider height so that it will always stay in contact with the floor
    private float adjustValue = 1f;

    private BoxCollider bCollider; //box collider that is responsible for detecting obstacle collision
    public BoxCollider hCollider; //horizontal collider

    public Transform horizontalHeels;

    /* heel model updaters*/
    public HeelModelUpdater[] modelUpdaters;

    public GameObject heel;
    public GameObject heelCollider;

    public Character character;


    private void Awake()
    {
        bCollider = GetComponent<BoxCollider>();
    }
    // Update is called once per frame
    public void IncreaseHeelHeight()  //increases heel height
    {
        heelCount += 1;     
        foreach(HeelModelUpdater updater in modelUpdaters)
        {
            updater.IncreaseHeelHeight();
        }
        UpdateCollissionArea();
    }
    public void DecreaseHeelHeight(int count) //decreases heel height by count 
    {
        heelCount -= count; //update heel count  
        foreach(HeelModelUpdater updater in modelUpdaters)
        {
            updater.DecreaseHeelHeight(count);
        }
        UpdateCollissionArea();
    }
    public void UpdateCharacterHeight(int count)  //updates character adjustment height according to the count variable
    {
        character.height = character.transform.position.y + heelHeight*count;
        Debug.Log("heigh:" + character.height);
        Debug.Log("heelcount" + heelCount);
    }
    public float HeelHeight()
    {
        return heelCount*heelHeight;
    }
    private void UpdateCollissionArea()  //updates collision detection are according to the heel quantity
    {
        bCollider.size = new Vector3(bCollider.size.x, heelCount * heelHeight + adjustHeight, bCollider.size.z);
        bCollider.center = new Vector3(0,  - (heelCount * heelHeight + adjustHeight) / 2 , 0);

        hCollider.size = new Vector3( 2*heelCount*heelHeight + adjustValue, hCollider.size.y, hCollider.size.z);
    }

    public void UpdateHeelOrientation(bool vertical)  //updates heel orientation of both colliders and models according to the floor type (!!)FIXME needs arrangement
    {
        if (!vertical)
        {
            horizontalHeels.gameObject.SetActive(true);
            character.SetGravity(true);
        }
        else
        {
            horizontalHeels.gameObject.SetActive(false);
            character.SetGravity(false);
            //character.BeginAdjustHeight();
        }
    }

    private void OnTriggerExit(Collider other)  
    {

        if (other.CompareTag(obstName))
        {
            int obstacleHeight = other.GetComponent<Obstacle>().obstacleHeight;
            DecreaseHeelHeight(obstacleHeight);
            UpdateCharacterHeight(-obstacleHeight);
            character.BeginAdjustHeight();
        }
        else if (other.CompareTag(railName))
        {
            UpdateCharacterHeight(heelCount);
            UpdateHeelOrientation(true);
            character.BeginAdjustHeight();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(heelPackName))
        {
            IncreaseHeelHeight();
            UpdateCharacterHeight(1);
            character.BeginAdjustHeight();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag(stepName))
        {
            int obstacleHeight = other.GetComponent<Obstacle>().obstacleHeight;
            DecreaseHeelHeight(obstacleHeight);
        }
        else if (other.CompareTag(railName))
        {
            UpdateHeelOrientation(false);
        }
        else if (other.CompareTag(floorName))
        {
            //UpdateHeelOrientation(true);
            //character.BeginAdjustHeight();
        } 
    }


}
