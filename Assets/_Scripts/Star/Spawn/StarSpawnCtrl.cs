using UnityEngine;

public class StarSpawnCtrl : MainBehavior
{
    [SerializeField] protected StarSpawner starSpawner;
    public StarSpawner StarSpawner { get => starSpawner; }

    [SerializeField] protected StarSpawnPoints spawnPoints;
    public StarSpawnPoints SpawnPoints { get => spawnPoints; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.starSpawner != null) return;
        this.starSpawner = GetComponent<StarSpawner>();
        Debug.Log(transform.name + ": LoadStarSpawner", gameObject);
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;
        this.spawnPoints = FindFirstObjectByType<StarSpawnPoints>();
        Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
    }
}
