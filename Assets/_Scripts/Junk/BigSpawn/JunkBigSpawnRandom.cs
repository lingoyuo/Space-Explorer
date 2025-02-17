using UnityEngine;

public class JunkBigSpawnRandom : MainBehavior
{
    [Header("Junk Random")]
    [SerializeField] protected JunkBigSpawnCtrl junkBigSpawnerCtrl;
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
        if (this.junkBigSpawnerCtrl != null) return;
        this.junkBigSpawnerCtrl = GetComponent<JunkBigSpawnCtrl>();
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

        Transform ranPoint = this.junkBigSpawnerCtrl.SpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.junkBigSpawnerCtrl.JunkBigSpawner.RandomPrefab();
        Transform obj = this.junkBigSpawnerCtrl.JunkBigSpawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);

        //Invoke(nameof(this.JunkSpawning), 5f);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.junkBigSpawnerCtrl.JunkBigSpawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}
