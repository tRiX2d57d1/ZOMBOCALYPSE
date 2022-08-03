using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int enemiesAlive = 0;

    public int round = 0;
    public int Scores = 0;
    public AudioSource myaudio;

    public GameObject[] spawnPoints;

    public GameObject enemyPrefab;
    public Text rounds;
    public Text Scoress;
    
    
    public GameObject endScreen;
    public Text EndScores;
    public Text EndRound;
    public GameObject finishscreen;
   
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesAlive == 0)
        {
            rounds.text = "Round: " + round.ToString();
            EndRound.text = round.ToString();
            
            round++;
            if (round == 10)
            {
                FinishGame();
            }


            NextWave(round);
            Scoress.text = "Score: " + Scores.ToString();
            EndScores.text = Scores.ToString();
            Scores += 20;
            
           


        }
    }

    public void NextWave(int round)
    {
        for (var x = 0; x < round; x++)
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            enemySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();
            enemiesAlive++;
            

        }

    }

    public void EndGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        endScreen.SetActive(true);
        
    }

    public void FinishGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        finishscreen.SetActive(true);

        myaudio.Play();
    }

   

    

}
