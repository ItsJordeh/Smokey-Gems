using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        //Resume time
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        //could freeze here with Time.timeScale = 0f;. Not implemented because our game is intended to be multiplayer
        GameIsPaused = true;
    }

    
    public void LoadMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
