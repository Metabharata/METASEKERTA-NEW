using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBackgroundMusic : MonoBehaviour
{
    private static MainMenuBackgroundMusic instance;
    private AudioSource audioSource;
    private bool isPlaying = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;
        if (sceneName.StartsWith("Bab"))
        {
            StopBacksound();
        }
        else
        {
            if (!isPlaying)
            {
                PlayBacksound();
            }
        }
    }

    public void StopBacksound()
    {
        audioSource.Stop();
        isPlaying = false;
    }

    public void PlayBacksound()
    {
        audioSource.Play();
        isPlaying = true;
    }
}
