using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button registerButton;
    public Button loginButton;
    public Button playButton;
    public Text playerUsernameDisplay; 

    private void Start()
    {
        if (DBManager.LoggedIn) {
            playerUsernameDisplay.text = "Usuário: " + DBManager.username;
        }

        registerButton.interactable = !DBManager.LoggedIn;
        loginButton.interactable = !DBManager.LoggedIn;
        playButton.interactable = DBManager.LoggedIn;
    }

    public void GoToMenu() 
    {
        SceneManager.LoadScene(0);
    }

    public void GoToRegister() 
    {
        SceneManager.LoadScene(1);
    }

    public void GoToLogin()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(3);
    }
}
