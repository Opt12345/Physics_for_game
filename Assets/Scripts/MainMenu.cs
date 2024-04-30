using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button creditButton;
    [SerializeField] private Button exitButton;
    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        creditButton.onClick.AddListener(ShowCredits);
        exitButton.onClick.AddListener(Quit);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("MapForPlay");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("Credit");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
