using UnityEngine;

public class EnemyDameReceiver : DamageReceiver
{
    [Header("Junk")]
    [SerializeField] protected EnemyCtrl enemyShipCtrl;
    public AudioManager audioManager;

    protected override void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.enemyShipCtrl != null) return;
        this.enemyShipCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }

    protected override void OnDead()
    {
        if (ShipPointReceiver.Instance != null)
        {
            ShipPointReceiver.Instance.AddAsteroidDestroyed();
        }
        OnDeadFX();
        audioManager.PlaySFX(audioManager.shipExplosionClip);
        this.enemyShipCtrl.EnemyShipDespawn.DespawnObject();
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke3;
    }
}
