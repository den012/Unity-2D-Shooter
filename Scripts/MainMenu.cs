using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    
    public void PlayGame()
    {
        LoadScene();
    }

    public void LoadScene()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("gameplay");
    }
}
