using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject winPanel;
    public GameObject losePanel;
    public static WinManager Instance { get; private set; }

    protected void Start()
    {
        Instance = this;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    public void CheckWinCondition()
    {
        if (ShipPointReceiveLevel1.Instance.point >= ShipPointReceiveLevel1.Instance.maxPoint && 
            ShipPointReceiveLevel1.Instance.numberDestroyAsteroid >= ShipPointReceiveLevel1.Instance.maxAsteroids)
        {
            WinGame();
        }
    }

    public void CheckWinConditionLevel2()
    {
        if (ShipPointReceiveLevel2.Instance.point >= ShipPointReceiveLevel2.Instance.maxPoint &&
            ShipPointReceiveLevel2.Instance.numberDestroyAsteroid >= ShipPointReceiveLevel2.Instance.maxAsteroids &&
            ShipPointReceiveLevel2.Instance.numberDestroyBigAsteroid >= ShipPointReceiveLevel2.Instance.maxBigAsteroids)
        {
            WinGame();
        }
    }

    public void CheckLoseCondition()
    {
        if (ShipLivesController.Instance.currentLive <= 0)
        {
            LoseGame();
        }
    }

    private void WinGame()
    {
        if (GameTimer.Instance != null)
            GameTimer.Instance.StopTimer();
        winPanel.SetActive(true); 
        Time.timeScale = 0f;
    }

    private void LoseGame()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
}
