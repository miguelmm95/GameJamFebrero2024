using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quitting the game");
        Application.Quit();
    }
}
