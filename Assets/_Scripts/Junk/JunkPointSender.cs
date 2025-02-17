using UnityEngine;

public class JunkPointSender : PointSender
{
    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
        this.point = -1;
    }

    protected virtual void LoadCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
    }

    public override void Send(PointReceive pointReceive)
    {
        base.Send(pointReceive);
        if (ShipLivesController.Instance != null) 
            ShipLivesController.Instance.RemoveLive();
        this.DestroyStar();
    }

    protected virtual void DestroyStar()
    {
        this.junkCtrl.JunkDespawn.DespawnObject();
    }
}
