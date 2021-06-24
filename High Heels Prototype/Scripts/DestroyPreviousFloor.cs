using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPreviousFloor : MonoBehaviour
{
    private BoxCollider bCollider;
    // Start is called before the first frame update
    private void Awake()
    {
        bCollider = GetComponent<BoxCollider>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            Destroy(other.gameObject);
        }
    }
}
