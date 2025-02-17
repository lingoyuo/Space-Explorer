using UnityEngine;

public class ParentFly : MainBehavior
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.right;

    void Update()
    {
        transform.parent.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
