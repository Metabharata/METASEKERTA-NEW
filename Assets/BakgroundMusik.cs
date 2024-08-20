// using UnityEngine.SceneManagement;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.Audio;


// public class BakgroundMusik : MonoBehaviour
// {
//     private static BackgroundMusik instance;

//     private AudioSource audioSource;

//     private void Awake()
//     {
//         if (instance == null)
//         {
//             instance = this;
//             DontDestroyOnLoad(gameObject);
//             audioSource = GetComponent<AudioSource>();
//         }
//         else
//         {
//             Destroy(gameObject);
//         }
//     }

//     public void SetVolume(float volume)
//     {
//         audioSource.volume = volume;
//     }
// }

