using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeelModelUpdater : MonoBehaviour
{
    public GameObject heel;
    public Transform creationPoint;

    private float heelHeight = -0.4f;  //pivot ters
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseHeelHeight()  //increases heel height and arranges the character height accordingly
    {
        creationPoint.transform.localPosition = new Vector3(creationPoint.localPosition.x, creationPoint.localPosition.y - heelHeight, creationPoint.localPosition.z);
        Instantiate(heel, creationPoint.position, creationPoint.rotation, transform);
    }

    public void DecreaseHeelHeight(GameObject heel) //decreases heel height and arranges the character height accordingly
    {
        Destroy(heel);
        creationPoint.transform.localPosition = new Vector3(creationPoint.localPosition.x, creationPoint.localPosition.y + heelHeight, creationPoint.localPosition.z);
    }
}
