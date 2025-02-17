using UnityEngine;

public class EnemyFollowTarget : MonoBehaviour
{
    [SerializeField] protected Transform target; // Mục tiêu (Player)
    [SerializeField] protected float speed = 2f; // Tốc độ di chuyển
    [SerializeField] protected float safeDistance = 5f; // Khoảng cách an toàn

    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    protected virtual void Following()
    {
        if (this.target == null) return;

        float distance = Vector3.Distance(transform.position, this.target.position);

        if (distance > this.safeDistance)
        {
            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(
                transform.position,
                this.target.position - (this.target.position - transform.position).normalized * this.safeDistance, // Vị trí cách xa một khoảng
                ref velocity,
                0.1f, // Thời gian mượt
                this.speed
            );
        }

        AvoidOtherEnemies();

        Vector3 direction = this.target.position - transform.position; 
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    private void AvoidOtherEnemies()
    {
        float separationRadius = 1.5f; // Bán kính khoảng cách để tránh
        float separationForce = 2f;   // Lực đẩy ra giữa các tàu

        Collider2D[] nearbyEnemies = Physics2D.OverlapCircleAll(transform.position, separationRadius);
        foreach (var enemy in nearbyEnemies)
        {
            if (enemy.transform != this.transform) // Không tính chính tàu này
            {
                Vector3 pushDirection = transform.position - enemy.transform.position; // Hướng đẩy ra xa
                transform.position += pushDirection.normalized * separationForce * Time.fixedDeltaTime;
            }
        }
    }

}
