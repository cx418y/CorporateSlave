using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    // public GameObject CreditsMenu;
    public GameObject AboutUsMenu;
    public Image backgroundImage;
    public string MainSceneName;
    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
    }

    public void StartGameButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainSceneName);
    }

    public void NewGameButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainSceneName);
    }

    public void AboutUsButton()
    {
        // Show Credits Menu
        MainMenu.SetActive(false);
       // AboutUsMenu.SetActive(true);
       // backgroundImage.color = new Color(0.3f, 0.3f, 0.3f, 1f);
    }

    public void BackButton()
    {
        // Show Credits Menu
        MainMenu.SetActive(true);
     //   AboutUsMenu.SetActive(false);
       // backgroundImage.color = new Color(1f, 1f, 1f, 1f);
    }

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