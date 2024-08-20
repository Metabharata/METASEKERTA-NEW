using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Screenout : MonoBehaviour
{
    public Image loadingFill1;
    public Image loadingFill2;
    public string sceneToLoad = "AwalMulai";
    public float loadingSpeed = 0.5f;

    void Start()
    {
        loadingFill1.fillAmount = 0f;
        loadingFill2.fillAmount = 0f;

        StartCoroutine(LoadSceneWithProgress());
    }

    IEnumerator LoadSceneWithProgress()
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        loadOperation.allowSceneActivation = false;

        float progress = 0f;

        while (progress < 1f)
        {
            float loadProgress = Mathf.Clamp(loadOperation.progress, 0f, 0.9f);


            if (progress < loadProgress)
            {
                progress = loadProgress;
            }


            progress += Time.deltaTime * loadingSpeed;

            float normalizedProgress = Mathf.Clamp01(progress);


            loadingFill1.fillAmount = normalizedProgress;
            loadingFill2.fillAmount = normalizedProgress;

            yield return null;
        }

        loadOperation.allowSceneActivation = true;
    }

}
