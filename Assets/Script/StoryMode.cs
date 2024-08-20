using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;

public class StoryMode : MonoBehaviour
{
    // Start is called before the first frame update
    public string baseUrl;
    public GameObject ObjLevel6, ObjLevel7;
    string tokenUser;
    void Start()
    {
        tokenUser = PlayerPrefs.GetString("token");
        StartCoroutine(GetStoryMode(tokenUser));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        // Metode untuk mendapatkan data dari server dengan token di header
    IEnumerator GetStoryMode(string authToken)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(baseUrl + "/api/story/"))
        {
            // Tambahkan header "Authorization" dengan nilai token ke dalam permintaan
            www.SetRequestHeader("Authorization", "Bearer " + authToken);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                Debug.Log("Data dari Server: " + responseText);

                JSONNode responseData = JSON.Parse(responseText);
                string level_6 = responseData["data"]["level_6"];
                string level_7 = responseData["data"]["level_7"];

                Debug.Log("Level 6: " + level_6);
                Debug.Log("Level 7: " + level_7);

                if (level_6 == "locked")
                {
                    ObjLevel6.SetActive(false);
                }else{
                    ObjLevel6.SetActive(true);
                }

                if (level_7 == "locked")
                {
                    ObjLevel7.SetActive(false);
                }else{
                    ObjLevel7.SetActive(true);
                }

                // Lakukan pengolahan data sesuai kebutuhan Anda di sini
            }
        }
    }
}
