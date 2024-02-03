using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField] GameObject weaponsParent;

    PauseManager pauseManager;

    private void Awake()
    {
        pauseManager = FindObjectOfType<PauseManager>();
    }
    public void GameOver()
    {
        pauseManager.PauseGame();
        GetComponent<PlayerMovement>().enabled = false;
        gameOverPanel.SetActive(true);
        weaponsParent.SetActive(false);
    }
}
