using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlMenu : MonoBehaviour
{
    public static ControlMenu instance;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject actionPanel;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text totalScoreText;
    [SerializeField] private float speedIncrease;
    private float maxSpeed = 8;
    private int sceneNumber = 0;
    private int score = -1;
    private int clickValue = 1;
    

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void DirectionChange()
    {
        if (!PlayerControl.instance.startGame)
        {
            PlayerControl.instance.startGame = true;
        }

        PlayerControl.instance.rigthMove = !PlayerControl.instance.rigthMove;
        AddScore(clickValue);
        if (PlayerControl.instance.playerSpeed < maxSpeed)
        {
            SpeedIncrease();
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        actionPanel.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif

    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
        totalScoreText.text = scoreText.text;
    }

    void SpeedIncrease()
    {
        PlayerControl.instance.playerSpeed += speedIncrease;
    }
}
