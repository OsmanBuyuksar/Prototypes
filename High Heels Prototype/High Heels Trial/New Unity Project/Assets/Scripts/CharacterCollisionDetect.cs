using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionDetect : MonoBehaviour
{
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
        if (other.gameObject.CompareTag("HeelPack"))
        {
            Destroy(other.gameObject);
            heelArrange.IncreaseHeelHeight();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            heelArrange.DecreaseHeelHeight(gameObject);
        }
        else
        {
            heelArrange.UpdateHeelOrientation(other.gameObject.tag);
        }
    }


}
