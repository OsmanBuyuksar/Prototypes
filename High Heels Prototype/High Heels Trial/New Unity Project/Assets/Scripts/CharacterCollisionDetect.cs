using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionDetect : MonoBehaviour
{

    private const string heelPackName = "HeelPack";
    private const string obstacleName = "Obstacle";
    private const string railName = "Rail";


    public GameStateController gameState;
    public HeelArrenger heelArrange;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameState.LoadRetryMenu();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(heelPackName))
        {
            Destroy(other.gameObject);
            heelArrange.IncreaseHeelHeight();
        }
        else if (other.gameObject.CompareTag(obstacleName))
        {
            gameState.LoadRetryMenu();
        }
        else if(other.gameObject.CompareTag(railName))
        {
            heelArrange.UpdateHeelOrientation(false);
        }
    }


}
