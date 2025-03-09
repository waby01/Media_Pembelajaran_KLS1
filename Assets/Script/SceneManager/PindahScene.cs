using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Sound()
    {

    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Play()
    {
        SceneManager.LoadScene("Loading");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void Penjelasan()
    {
        SceneManager.LoadScene("ScenePengenalan");
    }

    public void Quiz()
    {
        SceneManager.LoadScene("Kuis");
    }

    public void Profil()
    {
        SceneManager.LoadScene("Profil");
    }

}
