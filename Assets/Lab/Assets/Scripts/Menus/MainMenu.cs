using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void HandelHelpButton()
    {
        AudioManager.Play(AudioClipName.ClicButton);
        MenuManager.GoToMenu(MenuName.Help);
    }

    public void HandelQuiteButton()
    {
        AudioManager.Play(AudioClipName.ClicButton);
        Application.Quit();
    }

    public void GoToGame()
    {
        AudioManager.Play(AudioClipName.ClicButton);
        SceneManager.LoadScene("Lab");
    }

    public void GoToVido()
    {
        AudioManager.Play(AudioClipName.ClicButton);
        SceneManager.LoadScene("Vido");
    }

    
}
