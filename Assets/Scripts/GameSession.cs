using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation;

public class GameSession : MonoBehaviour
{
    public PathCreator pathCreator;
    public Slider gameProgress;
    public GameObject finishPanel;
    public GameObject gameOverPanel;
    public Text tapToStartText;

    private void Start()
    {
        gameProgress.maxValue = pathCreator.path.length;
    }

    public void ChangeProgressValue(float value)
    {
        gameProgress.value = value;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    public void Finish()
    {
        finishPanel.SetActive(true);
    }
}