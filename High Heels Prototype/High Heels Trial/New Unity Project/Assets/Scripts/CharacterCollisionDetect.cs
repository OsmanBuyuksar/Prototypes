using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionDetect : MonoBehaviour
{
    public GameStateController gameState;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("touchdown");
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameState.LoadDefaultLevel();
        }
    }
}
