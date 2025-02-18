using UnityEngine;

public class JunkPointSender : PointSender
{
    [SerializeField] protected JunkCtrl junkCtrl;
    public AudioManager audioManager;

    protected override void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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
        audioManager.PlaySFX(audioManager.meteoriteExplosionClip);
        this.DestroyStar();
    }

    protected virtual void DestroyStar()
    {
        this.junkCtrl.JunkDespawn.DespawnObject();
    }
}
