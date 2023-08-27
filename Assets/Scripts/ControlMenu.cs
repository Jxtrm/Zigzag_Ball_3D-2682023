using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    public static ControlMenu instance;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject actionPanel;
    private int sceneNumber = 0;

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
}
