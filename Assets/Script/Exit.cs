using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
