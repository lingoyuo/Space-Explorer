using UnityEngine;

public class EnemyCtrl : MainBehavior
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected EnemyDespawn enemyShipDespawn;
    public EnemyDespawn EnemyShipDespawn { get => enemyShipDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
    }

    protected virtual void LoadJunkDespawn()
    {
        if (this.enemyShipDespawn != null) return;
        this.enemyShipDespawn = transform.GetComponentInChildren<EnemyDespawn>();
    }
}
