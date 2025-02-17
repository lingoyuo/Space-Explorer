using UnityEngine;

public class JunkBigSpawnCtrl : MainBehavior
{
    [SerializeField] protected JunkBigSpawner junkBigSpawner;
    public JunkBigSpawner JunkBigSpawner { get => junkBigSpawner; }

    [SerializeField] protected JunkSpawnPoints spawnPoints;
    public JunkSpawnPoints SpawnPoints { get => spawnPoints; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.junkBigSpawner != null) return;
        this.junkBigSpawner = GetComponent<JunkBigSpawner>();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;
        this.spawnPoints = FindFirstObjectByType<JunkSpawnPoints>();
    }
}
