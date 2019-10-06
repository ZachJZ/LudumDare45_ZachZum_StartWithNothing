using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoaderLarry : MonoBehaviour
{
    //private GameObject controlOverview;
    //private GameObject controlOverview;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("StartLevel");
        Time.timeScale = 1;
    }

}
