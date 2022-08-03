using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float Health = 100;
    public Text HealthText;
    public GameManager gameManager;
    public GameObject gothitscreen;
    public void Hit(float damage)
    {
        Health-=damage;
        HealthText.text = Health.ToString() + " Health";
        if (Health <= 0)
        {
            gameManager.EndGame();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            gotHurt();
        }
    }

    void gotHurt()
    {
        var color = gothitscreen.GetComponent<Image>().color;
        color.a = 0.8f;
        gothitscreen.GetComponent<Image>().color = color;
    }
    // Update is called once per frame
    void Update()
    {
        if(gothitscreen!=null)
        {
            if(gothitscreen.GetComponent<Image>().color.a >0)
            {
                var color = gothitscreen.GetComponent<Image>().color;
                color.a -= 0.01f;
                gothitscreen.GetComponent<Image>().color = color;
            }

        }
    }
}
