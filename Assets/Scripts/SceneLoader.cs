using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	public void RunLevel0()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Credits()
    {
        SceneManager.LoadScene(1);
    }



    public void QuitGame()
    {
        Application.Quit();
    }
}
