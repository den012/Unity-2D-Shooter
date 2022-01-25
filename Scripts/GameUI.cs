using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("gameplay");
    }

    public void Home()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
