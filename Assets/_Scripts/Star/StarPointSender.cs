using UnityEngine;

public class StarPointSender : PointSender
{
    [SerializeField] protected StarCtrl starCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStarCtrl();
    }

    protected virtual void LoadStarCtrl()
    {
        if (this.starCtrl != null) return;
        this.starCtrl = transform.parent.GetComponent<StarCtrl>();
    }

    public override void Send(PointReceive pointReceive)
    {
        base.Send(pointReceive);
        this.DestroyStar();
    }

    protected virtual void DestroyStar()
    {
        this.starCtrl.StarDespawn.DespawnObject();
    }
}
