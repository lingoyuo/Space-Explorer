using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    [SerializeField] protected float speed = 2f;
    [SerializeField] protected float deceleration = 2f;
    private Vector3 currentVelocity = Vector3.zero;

    private void FixedUpdate()
    {
        MoveShip(InputManager.Instance.MoveDirection);
    }

    public void MoveShip(Vector3 direction)
    {
        if (direction.sqrMagnitude > 0.01f)
        {
            currentVelocity = direction * speed;
        }
        else
        {
            currentVelocity = Vector3.Lerp(currentVelocity, Vector3.zero, deceleration * Time.fixedDeltaTime);
        }

        transform.parent.position += currentVelocity * Time.fixedDeltaTime;
        LookAtDirection(currentVelocity);
        //transform.parent.position += direction * speed * Time.fixedDeltaTime;
        //LookAtDirection(direction);
    }

    protected virtual void LookAtDirection(Vector3 direction)
    {
        if (direction.sqrMagnitude > 0.01f)
        {
            float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
        }
    }
}
