using UnityEngine;

public class EnemyShipSpawnCtrl : MainBehavior
{
    [SerializeField] protected EnemyShipSpawner enemyShipSpawner;
    public EnemyShipSpawner EnemyShipSpawner { get => enemyShipSpawner; }

    [SerializeField] protected EnemyShipSpawnPoints spawnPoints;
    public EnemyShipSpawnPoints SpawnPoints { get => spawnPoints; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.enemyShipSpawner != null) return;
        this.enemyShipSpawner = GetComponent<EnemyShipSpawner>();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;
        this.spawnPoints = FindFirstObjectByType<EnemyShipSpawnPoints>();
    }
}
