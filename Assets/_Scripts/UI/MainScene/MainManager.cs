using UnityEngine;

public class MainManager : MonoBehaviour
{
    public GameObject pausePanel; // Gán PausePanel trong Inspector
    public GameObject controllPanel;
    private bool isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pausePanel.SetActive(false);
        controllPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMainMenu()
    {
        isPaused = true;
        Time.timeScale = 0; // Dừng game
        pausePanel.SetActive(true); // Hiện PausePanel
    }

    public void OpenControllMenu()
    {
        isPaused = true;
        Time.timeScale = 0; 
        controllPanel.SetActive(true); 
    }

    public void CloseControllMenu()
    {
        isPaused = false;
        Time.timeScale = 1;
        controllPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
