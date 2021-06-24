using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heelCollisionDetect : MonoBehaviour
{

    private HeelArrenger heelArrange;
    private bool collided = false;
    // Start is called before the first frame update
    void Start()
    {
        heelArrange = GameObject.FindGameObjectWithTag("HeelArranger").GetComponent<HeelArrenger>();
    }
    private void OnTriggerEnter(Collider other)  
    {
        if (other.gameObject.CompareTag("HeelPack"))
        {
            Destroy(other.gameObject);
            heelArrange.IncreaseHeelHeight();
        }
        else if (other.gameObject.CompareTag("Obstacle") && !collided)
        {
            collided = true;
            heelArrange.DecreaseHeelHeight(gameObject);
        }
        
    }
}
