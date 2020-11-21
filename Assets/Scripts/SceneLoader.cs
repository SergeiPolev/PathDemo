using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        if (!PlayerPrefs.HasKey("First Time"))
        {
            PlayerPrefs.SetString("First Time", "No");
            PlayerPrefs.SetInt("Current Level", 1);
        }
    }
    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextLevel()
    {
        PlayerPrefs.SetInt("Current Level", SceneManager.GetActiveScene().buildIndex + 2);

        if (SceneManager.sceneCountInBuildSettings < PlayerPrefs.GetInt("Current Level"))
        {
            PlayerPrefs.SetInt("Current Level", PlayerPrefs.GetInt("Current Level") - 1);
        }
        SceneManager.LoadScene("Level " + PlayerPrefs.GetInt("Current Level")); ;
    }
}