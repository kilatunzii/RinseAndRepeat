using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject howToPlayPanel;
    public void ShowHowToPlayPanel()
    {
        howToPlayPanel.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("life");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
