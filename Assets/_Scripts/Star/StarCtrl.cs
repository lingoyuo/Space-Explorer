using UnityEngine;

public class StarCtrl : MainBehavior
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected StarDespawn starDespawn;
    public StarDespawn StarDespawn { get => starDespawn; }

    [SerializeField] protected PointSender pointSender;
    public PointSender PointSender { get => pointSender; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
        this.LoadPointSender();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
    }

    protected virtual void LoadPointSender()
    {
        if (this.pointSender != null) return;
        this.pointSender = transform.GetComponentInChildren<PointSender>();
    }

    protected virtual void LoadJunkDespawn()
    {
        if (this.starDespawn != null) return;
        this.starDespawn = transform.GetComponentInChildren<StarDespawn>();
    }
}
