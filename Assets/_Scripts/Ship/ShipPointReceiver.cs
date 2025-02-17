using UnityEngine;

public class ShipPointReceiver : PointReceive
{
    public static ShipPointReceiver Instance { get; private set; }

    protected override void Start()
    {
        base.Start();
        Instance = this;
    }

    public virtual void AddAsteroidDestroyed() { }
    public virtual void AddBigAsteroidDestroyed() { }
}
