using UnityEngine;

public class StarAbstract : MainBehavior
{
    [Header("Star Abtract")]
    [SerializeField] protected StarCtrl starCtrl;
    public StarCtrl StarCtrl { get => starCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStarAbstract();
    }

    protected virtual void LoadStarAbstract()
    {
        if (this.starCtrl != null) return;
        this.starCtrl = transform.parent.GetComponent<StarCtrl>();
    }
}
