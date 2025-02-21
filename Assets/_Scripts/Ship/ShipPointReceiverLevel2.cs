using TMPro;
using UnityEngine;

public class ShipPointReceiveLevel2 : ShipPointReceiver
{
    public static ShipPointReceiveLevel2 Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    public int maxPoint = 100;  
    public TextMeshProUGUI blastTheAsteroidsText;
    public int maxAsteroids = 50;
    [SerializeField] public int numberDestroyAsteroid = 0;
    public TextMeshProUGUI blastTheBigAsteroidsText;
    public int maxBigAsteroids = 10;
    [SerializeField] public int numberDestroyBigAsteroid = 0;

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

        if (this.point <= 0) this.point = 0;

        if (scoreText != null && blastTheAsteroidsText != null)
            WinManager.Instance.CheckWinConditionLevel2();
    }

    public override void AddAsteroidDestroyed()
    {
        if (numberDestroyAsteroid < maxAsteroids)
        {
            numberDestroyAsteroid++;
            UpdateScoreUI();
        }

        if (scoreText != null && blastTheAsteroidsText != null)
            WinManager.Instance.CheckWinConditionLevel2();
    }

    public override void AddBigAsteroidDestroyed()
    {
        if (numberDestroyBigAsteroid < maxBigAsteroids)
        {
            numberDestroyBigAsteroid++;
            UpdateScoreUI();
        }
        if (scoreText != null && blastTheBigAsteroidsText != null)
            WinManager.Instance.CheckWinConditionLevel2();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            if (this.point <= 0) this.point = 0;

            scoreText.text = "Score: " + this.point + "/" + maxPoint;
        }

        if (blastTheAsteroidsText != null)
        {
            blastTheAsteroidsText.text = "Blast the asteroids: " + this.numberDestroyAsteroid + "/" + maxAsteroids;
        }

        if (blastTheBigAsteroidsText != null)
        {
            blastTheBigAsteroidsText.text = "Blast the big asteroids: " + this.numberDestroyBigAsteroid + "/" + maxBigAsteroids;
        }
    }

}
