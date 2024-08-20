using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegisterController : MonoBehaviour
{
    public string baseUrl;
    public InputField name;
    public InputField email;
    public InputField username;
    public InputField password;
    public GameObject success;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AccountRegister()
    {
        string uName = name.text;
        string uEmail = email.text;
        string uUsername = username.text; // Ambil teks dari InputField username
        string pWord = password.text;
        StartCoroutine(RegisterNewAccount(uName, uEmail, uUsername, pWord)); // Sertakan uUsername
    }

    public void lanjutkan(){
        SceneManager.LoadScene("AwalMulai");
    }

    IEnumerator RegisterNewAccount(string uName, string uEmail, string uUsername, string pWord)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", uName);
        form.AddField("email", uEmail);
        form.AddField("username", uUsername); // Kirim username ke server
        form.AddField("password", pWord);

        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl + "/api/users/register", form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError("Error: " + www.error);
                Debug.LogError("Status Code: " + www.responseCode);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                Debug.Log("Response = " + responseText);
                success.SetActive(true);
            }
        }
    }
}
