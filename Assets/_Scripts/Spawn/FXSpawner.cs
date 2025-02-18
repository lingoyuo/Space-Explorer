using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance { get => instance; }
    public static string smoke1 = "Smoke_1";
    public static string smoke2 = "Smoke_2";
    public static string smoke3 = "Explosion_1";
    public static string impact1 = "Impact_1";

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 FXSpawner allow to exist");
        instance = this;
    }
}
