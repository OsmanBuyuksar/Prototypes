using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heelCollisionDetect : MonoBehaviour
{
    private string heelPackName = "HeelPack";

    private HeelArrenger heelArrange;
    private bool collided = false;
    // Start is called before the first frame update
    void Start()
    {
        heelArrange = GameObject.FindGameObjectWithTag("HeelArranger").GetComponent<HeelArrenger>();
    }
    private void OnTriggerEnter(Collider other)  
    {
        if (other.gameObject.CompareTag(heelPackName))
        {
            Destroy(other.gameObject);
            heelArrange.IncreaseHeelHeight();
        }       
    }
}
