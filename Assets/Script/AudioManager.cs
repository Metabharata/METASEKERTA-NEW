using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource narratorAudio;
    public GameObject berikutnyaButton;
    public GameObject sebelumnyaButton;

    private void Start()
    {

        narratorAudio.playOnAwake = false;
        narratorAudio.loop = false;
        narratorAudio.pitch = 1f;
        narratorAudio.Play();
        berikutnyaButton.gameObject.SetActive(false);
        sebelumnyaButton.gameObject.SetActive(false);
        StartCoroutine(ShowButtonWhenAudioFinished());
    }

    private IEnumerator ShowButtonWhenAudioFinished()
    {
        while (narratorAudio.isPlaying)
        {
            yield return null;
        }
        berikutnyaButton.gameObject.SetActive(true);
        sebelumnyaButton.gameObject.SetActive(true);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("BabSatua");
    }
}
