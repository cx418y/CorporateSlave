using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    // public GameObject CreditsMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
    }

    public void PlayNowButton()
    {
        Debug.Log("������PlayNowButton");
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        // 最好换个能在外面配置的写法
        UnityEngine.SceneManagement.SceneManager.LoadScene("Windows");
    }

    public void MainMenuButton()
    {
        Debug.Log("������MainMenu");
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("ChooseLocation");
    }

    /* public void CreditsButton()
     {
         // Show Credits Menu
         MainMenu.SetActive(false);
         CreditsMenu.SetActive(true);
     }*/

    /*public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        // CreditsMenu.SetActive(false);
    }*/

    public void QuitButton()
    {
        Debug.Log("������QuitButton");
        // Quit Game    
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif

    }
}