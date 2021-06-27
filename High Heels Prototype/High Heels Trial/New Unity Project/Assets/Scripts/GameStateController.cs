using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public Canvas retryMenu;
    public Canvas inGameMenu;
    public void LoadDefaultLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void LoadRetryMenu()
    {
        retryMenu.gameObject.SetActive(true);
        inGameMenu.gameObject.SetActive(false);
        Time.timeScale = 0;
    }
}
