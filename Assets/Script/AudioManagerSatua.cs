using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManagerSatua : MonoBehaviour
{
    public AudioSource narratorAudio;
    public GameObject berikutnyaButton;
    public GameObject sebelumnyaButton;

    public float delayBeforeStart = 21f;

    private void Start()
    {
        narratorAudio.playOnAwake = false;
        narratorAudio.loop = false;
        narratorAudio.pitch = 1f;

        berikutnyaButton.gameObject.SetActive(false);
        sebelumnyaButton.gameObject.SetActive(false);
        StartCoroutine(StartAudioWithDelay());
    }

    private IEnumerator StartAudioWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeStart);

        narratorAudio.Play();
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
