using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitAllert : MonoBehaviour
{
    [SerializeField] GameObject quitPanel;

    public void QuitGame()
    {
        Application.Quit();
    }
    public void KonfirmYes()
    {
        quitPanel.SetActive(true);
    }
    public void KonfirmNo()
    {
        quitPanel.SetActive(false);
    }
}
