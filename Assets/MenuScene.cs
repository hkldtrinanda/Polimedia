using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScene : MonoBehaviour
{
    public GameObject mainMenu, settingsMenu, creditsMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
    
    public void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
    
    public void OpenCredits()
    {
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }
    
    public void Back()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
}
