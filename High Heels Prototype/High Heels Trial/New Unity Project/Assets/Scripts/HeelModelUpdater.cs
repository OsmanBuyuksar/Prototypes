using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeelModelUpdater : MonoBehaviour
{
    public GameObject heel;
    public Transform creationPoint;

    private float heelHeight = -0.5f;  //pivot ters

    private Stack heels = new Stack();
    public void IncreaseHeelHeight()  //increases heel height and arranges the character height accordingly
    {
        creationPoint.transform.localPosition = new Vector3(creationPoint.localPosition.x, creationPoint.localPosition.y - heelHeight, creationPoint.localPosition.z);
        GameObject obj = Instantiate(heel, creationPoint.position, creationPoint.rotation, transform);
        heels.Push(obj);
    }

    public void DecreaseHeelHeight(int count) //decreases heel height and arranges the character height accordingly
    {
        for (int i = 0; i < count; i++)
        {
            Destroy((GameObject)heels.Pop());
            creationPoint.transform.localPosition = new Vector3(creationPoint.localPosition.x, creationPoint.localPosition.y + heelHeight, creationPoint.localPosition.z);
        }
    }
}
