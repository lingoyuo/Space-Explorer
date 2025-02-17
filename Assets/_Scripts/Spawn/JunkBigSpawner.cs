using UnityEngine;

public class JunkBigSpawner : Spawner
{
    private static JunkBigSpawner instance;
    public static JunkBigSpawner Instance { get => instance; }

    public static string meteoriteOne = "Meteorite_1";

    protected override void Awake()
    {
        base.Awake();
        if (JunkBigSpawner.instance != null) Debug.LogError("Only 1 JunkBigSpawner allow to exist");
        JunkBigSpawner.instance = this;
    }
}
