using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeelModelUpdater : MonoBehaviour
{
    public GameObject heel;
    public Transform creationPoint;

    private float heelHeight = -0.4f;  //pivot ters
    private string heelName;

    // Start is called before the first frame update
    void Start()
    {
        heelName = heel.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseHeelHeight(int heelCount)  //increases heel height and arranges the character height accordingly
    {
        creationPoint.transform.localPosition = new Vector3(creationPoint.localPosition.x, creationPoint.localPosition.y - heelHeight, creationPoint.localPosition.z);
        GameObject obj = Instantiate(heel, creationPoint.position, creationPoint.rotation, transform);
        obj.name = heelName + heelCount;
    }

    public void DecreaseHeelHeight(int heelCount) //decreases heel height and arranges the character height accordingly
    {
        GameObject obj = GameObject.Find(heelName + heelCount);  //note to myself: u can store the heels in an array instead of trying to find them by name
        Destroy(obj);
        creationPoint.transform.localPosition = new Vector3(creationPoint.localPosition.x, creationPoint.localPosition.y + heelHeight, creationPoint.localPosition.z);
    }
}
