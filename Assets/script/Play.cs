using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public string mainPlayLoad;
    public void MainPlay()
    {
        SceneManager.LoadScene(mainPlayLoad);
    }

    public void leavegame()
    {
        Application.Quit();
    }
}