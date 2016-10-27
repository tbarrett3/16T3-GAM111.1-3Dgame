using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	public void RunLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
