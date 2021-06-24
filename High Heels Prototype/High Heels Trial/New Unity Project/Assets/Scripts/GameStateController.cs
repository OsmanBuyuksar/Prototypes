using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public void LoadDefaultLevel()
    {
        SceneManager.LoadScene(0);
    }
}
