using UnityEngine;

public class EnemyShipSpawnRandom : MainBehavior
{
    [Header("Junk Random")]
    [SerializeField] protected EnemyShipSpawnCtrl enemyShipSpawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 10f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.enemyShipSpawnerCtrl != null) return;
        this.enemyShipSpawnerCtrl = GetComponent<EnemyShipSpawnCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void Start()
    {
        //this.JunkSpawning();
    }

    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;

        Transform ranPoint = this.enemyShipSpawnerCtrl.SpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.enemyShipSpawnerCtrl.EnemyShipSpawner.RandomPrefab();
        Transform obj = this.enemyShipSpawnerCtrl.EnemyShipSpawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);

        //Invoke(nameof(this.JunkSpawning), 5f);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.enemyShipSpawnerCtrl.EnemyShipSpawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}
