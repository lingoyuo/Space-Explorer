using UnityEngine;

public class ShipDamageReceiver : DamageReceiver
{
    public override void Deduct(int deduct)
    {
        ShipLivesController.Instance.RemoveLive();
    }
    
    protected override void OnDead()
    {
    }
}
