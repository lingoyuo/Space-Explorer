using UnityEngine;

public class StarDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        StarSpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 20f;
    }
}
