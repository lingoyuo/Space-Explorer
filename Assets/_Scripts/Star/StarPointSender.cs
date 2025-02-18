using UnityEngine;

public class StarPointSender : PointSender
{
    [SerializeField] protected StarCtrl starCtrl;
    public AudioManager audioManager;

    protected override void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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
        audioManager.PlaySFX(audioManager.starClip);
        this.DestroyStar();
    }

    protected virtual void DestroyStar()
    {
        this.starCtrl.StarDespawn.DespawnObject();
    }
}
