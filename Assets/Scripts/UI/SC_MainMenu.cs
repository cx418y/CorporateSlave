using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_MainMenu : MonoBehaviour
{
    public Image backgroundImage;
    public GameObject MainMenu;
    public GameObject AboutUsMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
    }

    public void PlayNowButton()
    {
        
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("ChooseLocation");
    }

    public void MainMenuButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("ChooseLocation");
    }

    public void AboutUsButton()
    {
        // Show Credits Menu
        MainMenu.SetActive(false);
        AboutUsMenu.SetActive(true);
        backgroundImage.color = new Color(0.3f, 0.3f, 0.3f, 1f);
    }

    public void BackButton()
    {
        // Show Credits Menu
        MainMenu.SetActive(true);
        AboutUsMenu.SetActive(false);
        backgroundImage.color = new Color(1f, 1f, 1f, 1f);
    }

    /*public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        // CreditsMenu.SetActive(false);
    }*/

    public void QuitButton()
    {
        // Quit Game    
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif

    }
}