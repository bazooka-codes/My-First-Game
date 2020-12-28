using UnityEngine;
using UnityEngine.SceneManagement;

public class MMGameManager : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
