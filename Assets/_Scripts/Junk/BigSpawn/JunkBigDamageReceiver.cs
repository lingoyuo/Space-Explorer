using UnityEngine;

public class JunBigDamageReceiver : DamageReceiver
{
    [Header("Junk")]
    [SerializeField] protected JunkCtrl junkCtrl;
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
        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
    }

    protected override void OnDead()
    {
        if (ShipPointReceiver.Instance != null)
        {
            ShipPointReceiver.Instance.AddBigAsteroidDestroyed();
        }
        OnDeadFX();
        audioManager.PlaySFX(audioManager.bigMeteoriteExplosionClip);
        this.junkCtrl.JunkDespawn.DespawnObject();
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke2;
    }
}
