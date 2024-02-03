using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    [SerializeField] float timeToCompleteLevel;

    StageTime stageTime;

    [SerializeField] GameWinPanel levelCompletePanel;

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
        levelCompletePanel = FindObjectOfType<GameWinPanel>(true);
    }

    private void Update()
    {
        if(stageTime.time > timeToCompleteLevel)
        {
            levelCompletePanel.gameObject.SetActive(true);
        }
    }
}
