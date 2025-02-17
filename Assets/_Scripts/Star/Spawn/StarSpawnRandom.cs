using UnityEngine;

public class StarSpawnRandom : MainBehavior
{
    [Header("Star Random")]
    [SerializeField] protected StarSpawnCtrl starSpawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 15f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.starSpawnerCtrl != null) return;
        this.starSpawnerCtrl = GetComponent<StarSpawnCtrl>();
        Debug.Log(transform.name + ": LoadStarCtrl", gameObject);
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

        Transform ranPoint = this.starSpawnerCtrl.SpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.starSpawnerCtrl.StarSpawner.RandomPrefab();
        Transform obj = this.starSpawnerCtrl.StarSpawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);

        //Invoke(nameof(this.JunkSpawning), 5f);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.starSpawnerCtrl.StarSpawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}
