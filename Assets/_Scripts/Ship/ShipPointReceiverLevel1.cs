using TMPro;
using UnityEngine;

public class ShipPointReceiveLevel1 : ShipPointReceiver
{
    public static ShipPointReceiveLevel1 Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    public int maxPoint = 100;  
    public TextMeshProUGUI blastTheAsteroidsText;
    public int maxAsteroids = 50;
    [SerializeField] public int numberDestroyAsteroid = 0;

    protected override void Start()
    {
        base.Start();
        Instance = this;
        UpdateScoreUI();
    }

    public override void AddPoint(int point)
    {
        if (this.point < maxPoint)
        {
            base.AddPoint(point);
            UpdateScoreUI();
        }

        if (scoreText != null && blastTheAsteroidsText != null)
            WinManager.Instance.CheckWinCondition();
    }

    public override void AddAsteroidDestroyed()
    {
        if (numberDestroyAsteroid < maxAsteroids)
        {
            numberDestroyAsteroid++;
            UpdateScoreUI();
        }

        if (scoreText != null && blastTheAsteroidsText != null)
            WinManager.Instance.CheckWinCondition();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + this.point + "/" + maxPoint;
        }

        if (blastTheAsteroidsText != null)
        {
            blastTheAsteroidsText.text = "Blast the asteroids: " + this.numberDestroyAsteroid + "/" + maxAsteroids;
        }
    }

}
