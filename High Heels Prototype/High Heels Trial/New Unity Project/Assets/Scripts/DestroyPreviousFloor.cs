using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPreviousFloor : MonoBehaviour  //destroy floors that touches the destroyPoint
{
    private BoxCollider bCollider;
    private void Awake()
    {
        bCollider = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            Destroy(other.gameObject);    
        }
    }
}
