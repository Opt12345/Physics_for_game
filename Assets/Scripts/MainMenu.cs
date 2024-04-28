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
        SceneManager.LoadScene("");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
