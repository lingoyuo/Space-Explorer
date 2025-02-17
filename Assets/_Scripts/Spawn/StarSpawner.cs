using UnityEngine;

public class StarSpawner : Spawner
{
    private static StarSpawner instance;
    public static StarSpawner Instance { get => instance; }

    public static string meteoriteOne = "Meteorite_1";

    protected override void Awake()
    {
        base.Awake();
        if (StarSpawner.instance != null) Debug.LogError("Only 1 StarSpawner allow to exist");
        StarSpawner.instance = this;
    }
}
