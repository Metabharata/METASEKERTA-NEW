using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    public string baseUrl;
    public InputField username;
    public InputField password;
    public GameObject errors;
    // Start is called before the first frame update

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void AccountLogin()
    {
        string uSername = username.text;
        string pWord = password.text;
        StartCoroutine(LogInAccount(uSername, pWord));
    }

    public void UlangiLogin(){
        errors.SetActive(false);
    }

    public void RegisterPage(){
        SceneManager.LoadScene("Register");
    }

    IEnumerator LogInAccount(string uSername, string pWord)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", uSername);
        form.AddField("password", pWord);
        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl + "/api/users/login", form))
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
                Debug.Log("Response = " + responseText);

                JSONNode responseData = JSON.Parse(responseText);
                string accessToken = responseData["data"]["access_token"];
                int userId = responseData["data"]["user"]["id"].AsInt;
                int statusCode = responseData["meta"]["code"].AsInt;

                Debug.Log("Access Token: " + accessToken);
                Debug.Log("User ID: " + userId);
                Debug.Log("Status Code: " + statusCode);

                if (statusCode == 200)
                {
                    PlayerPrefs.SetString("token", accessToken);
                    PlayerPrefs.SetInt("id", userId);
                    SceneManager.LoadScene("Loading");
                }
                else
                {
                    errors.SetActive(true);
                }
            }
        }
    }
}
