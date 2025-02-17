using UnityEngine;

public abstract class PointReceive : MainBehavior
{
    [Header("Point Receiver")]
    [SerializeField] public int point = 0;

    public virtual void AddPoint(int point)
    {
        this.point += point;
    }
}
