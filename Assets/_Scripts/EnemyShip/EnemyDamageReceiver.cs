using UnityEngine;

public class EnemyDameReceiver : DamageReceiver
{
    [Header("Junk")]
    [SerializeField] protected EnemyCtrl enemyShipCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.enemyShipCtrl != null) return;
        this.enemyShipCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }

    protected override void OnDead()
    {
        if (ShipPointReceiver.Instance != null)
        {
            ShipPointReceiver.Instance.AddAsteroidDestroyed();
        }
        this.enemyShipCtrl.EnemyShipDespawn.DespawnObject();
    }
}
