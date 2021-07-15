using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour  //store obstacle height and set box collider height at start
{
    public int obstacleHeight = 1;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider collider = gameObject.GetComponent<BoxCollider>();
        collider.size = new Vector3(collider.size.x, obstacleHeight, collider.size.z);
        collider.center = new Vector3(0, obstacleHeight/2f, 0);
    }
}
