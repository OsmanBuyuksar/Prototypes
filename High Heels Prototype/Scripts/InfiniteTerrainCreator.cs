using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteTerrainCreator : MonoBehaviour
{
    public Transform generationPoint;
    public Transform createPoint;
    public Transform destroyPoint;

    public GameObject floor;

    private float floorLength;
    // Start is called before the first frame update
    void Start()
    {
        floorLength = floor.GetComponent<BoxCollider>().size.z;
        Debug.Log("floorLength:" + floorLength);
    }

    // Update is called once per frame
    void Update()
    {
        if (true)//FIXME : gamestate konrolü eklenecek
        { 
            if(generationPoint.position.z < createPoint.position.z)
            {
                MoveGenerationPoint();
                CreateNextFloor();
            }
        }
    }
    void MoveGenerationPoint()
    {
        generationPoint.transform.position = new Vector3(generationPoint.transform.position.x, generationPoint.transform.position.y, generationPoint.transform.position.z + floorLength);
    }

    void CreateNextFloor()
    {
        Instantiate(floor, generationPoint.transform.position, floor.transform.rotation);
    }
    void DestroyPreviousFloor()
    {

    }
}
