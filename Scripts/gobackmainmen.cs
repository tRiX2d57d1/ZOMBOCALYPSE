using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class gobackmainmen : MonoBehaviour
{    public GameObject pausescreen;

    
    public void mainmenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Login");
    }
    public void level3()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level3");
    }
    public void level1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }
    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void quitgame()
    {
        Application.Quit(); 
    }
    public void Continue()
    {
        Time.timeScale = 1;
        pausescreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                pausescreen.SetActive(true);
            }
        }
    }
}
