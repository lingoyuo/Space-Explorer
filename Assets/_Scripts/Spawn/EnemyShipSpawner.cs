using UnityEngine;

public class EnemyShipSpawner : Spawner
{
    private static EnemyShipSpawner instance;
    public static EnemyShipSpawner Instance { get => instance; }

    public static string meteoriteOne = "Meteorite_1";

    protected override void Awake()
    {
        base.Awake();
        if (EnemyShipSpawner.instance != null) Debug.LogError("Only 1 EnemyShipSpawner allow to exist");
        EnemyShipSpawner.instance = this;
    }
}
