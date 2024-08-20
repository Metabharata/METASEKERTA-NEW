using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundEvent : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;

    private AudioSource backgroundMusic;

    private float value;

    private void Start()
    {
        Time.timeScale = 1;
        mixer.GetFloat("volume", out value);
        volumeSlider.value = value;

        backgroundMusic = FindObjectOfType<MainMenuBackgroundMusic>().GetComponent<AudioSource>();
        volumeSlider.onValueChanged.AddListener(SetVolume); // Add listener to call SetVolume when slider changes
    }

    public void SetVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
        backgroundMusic.volume = volume;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadModeCerita()
    {
        // Beritahu BacksoundPlayer untuk menghentikan pemutaran backsound saat berpindah ke "ModeCerita"
        MainMenuBackgroundMusic backsoundPlayer = FindObjectOfType<MainMenuBackgroundMusic>();
        if (backsoundPlayer != null)
        {
            backsoundPlayer.StopBacksound();
        }
        SceneManager.LoadScene("ModeCerita");
    }
}
