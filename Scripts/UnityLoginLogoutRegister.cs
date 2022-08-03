using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class UnityLoginLogoutRegister : MonoBehaviour
{

    public string baseUrl = "http://localhost/Unity/";


    public InputField accountUserName;
    public InputField accountPassword;
    public Text info;
    
    
    public string currentUsername;
    private string ukey = "accountusername";
    

    // Start is called before the first frame update
    void Start()
    {
        currentUsername = "";

        if (PlayerPrefs.HasKey(ukey))
        {
            if (PlayerPrefs.GetString(ukey) != "")
            {
                currentUsername = PlayerPrefs.GetString(ukey);
                info.text = "You are logged in = " + currentUsername;
            }
            else
            {
                info.text = "Enter a username and password";
            }
        }
        else
        {
            info.text = "You are not logged in.";
        }
       

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AccountLogout()
    {
        currentUsername = "";
        PlayerPrefs.SetString(ukey, currentUsername);
        info.text = "You just logged out.";
    }

    public void AccountRegister()
    {
        string uName = accountUserName.text;
        string pWord = accountPassword.text;
        StartCoroutine(RegisterNewAccount(uName, pWord));
    }

    public void AccountLogin()
    {
        string uName = accountUserName.text;
        string pWord = accountPassword.text;
        StartCoroutine(LogInAccount(uName, pWord));
    }

   
    
    public void GoToLogin()
    {
        SceneManager.LoadSceneAsync("Login");
    }

    public void GoToRegister()
    {
        SceneManager.LoadSceneAsync("Register");
    }

   
    IEnumerator RegisterNewAccount(string uName, string pWord)
    {
        WWWForm form = new WWWForm();
        form.AddField("newAccountUsername", uName);
        form.AddField("newAccountPassword", pWord);
        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                Debug.Log(responseText);
                info.text =responseText;
            }
        }
    }

    IEnumerator LogInAccount(string uName, string pWord)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUsername", uName);
        form.AddField("loginPassword", pWord);
        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                if (responseText == "1")
                {
                    PlayerPrefs.SetString(ukey, uName);
                    //info.text = "Login Success with username " + uName;
                    SceneManager.LoadSceneAsync("Tutorial");
                }
                else
                {
                    info.text = "Wrong Username or Password";
                }
            }
        }
    }
 }