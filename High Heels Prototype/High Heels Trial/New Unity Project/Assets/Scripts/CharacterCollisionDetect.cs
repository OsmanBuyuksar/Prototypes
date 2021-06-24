using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionDetect : MonoBehaviour
{
    private GameStateContoller gameState;
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<GameStateContoller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameState.LoadDefaultLevel();
        }
    }
}
