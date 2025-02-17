using UnityEngine;

public class EnemyShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.1f;
    [SerializeField] protected float shootTimer = 0f;

    [SerializeField] protected float autoShootInterval = 1f; 
    private float autoShootTimer = 0f; 

    void Update()
    {
        AutoShoot();
    }

    private void FixedUpdate()
    {
        Shooting();
    }

    protected virtual void Shooting()
    {
        if (!isShooting) return;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation * Quaternion.Euler(0, 0, 90);
        //Transform newBullet = Instantiate(bulletPrefab, spawnPos, rotation);
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        if (newBullet == null) return;

        newBullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShotter(transform.parent);
    }

    protected virtual bool IsShooting()
    {
        isShooting = InputManager.Instance.OnFiring == 1;
        return isShooting;
    }

    private void AutoShoot()
    {
        autoShootTimer += Time.deltaTime;

        if (autoShootTimer >= autoShootInterval)
        {
            isShooting = true; // Bắt đầu bắn khi đến thời gian tự động
            autoShootTimer = 0f; // Reset lại bộ đếm thời gian tự động
        }
        else
        {
            isShooting = false; // Không bắn nếu chưa đến thời gian tự động
        }
    }
}
