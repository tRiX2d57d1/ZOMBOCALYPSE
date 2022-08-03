using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SwapScenes : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject finishScreen;
    public AudioSource MyAudioSource;
    public AudioSource MyAudio2;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Checks if enemies are available with tag "Enemy". Note that you should set this to your enemies in the inspector.
        if (enemies.Length == 0)
        {
            
            finishScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            if (finishScreen == true)
            {
                
                if (Time.timeScale == 1)
                {
                    MyAudioSource.Stop();
                    
                }
            }
            

        }

       if (SceneManager.GetActiveScene().name == "Level1" && SceneManager.GetActiveScene().name == "Level3")
            Dontdestroyaudio.instance.GetComponent<AudioSource>().Pause();
    }
   

}
