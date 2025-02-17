using UnityEngine;

public class EnemyDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        EnemyShipSpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 20f;
    }
}
