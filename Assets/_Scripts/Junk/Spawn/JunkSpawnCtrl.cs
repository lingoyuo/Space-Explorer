using UnityEngine;

public class JunkSpawnCtrl : MainBehavior
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => junkSpawner; }

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
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;
        this.spawnPoints = FindFirstObjectByType<JunkSpawnPoints>();
        Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
    }
}
