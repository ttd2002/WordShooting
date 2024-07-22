using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : WMonobehaviour
{
    private static BulletController instance;
    public static BulletController Instance { get => instance; }
    protected BulletFly bulletFly;
    protected override void Awake()
    {
        base.Awake();
        if (BulletController.instance != null) Debug.LogError("Only 1 BulletController allow to exist");
        BulletController.instance = this;
    }
    
    public virtual Transform SpawnBullet(Vector3 spawnPos, Quaternion rotation, Vector3 direction)
    {
        BulletModel bulletModel = new BulletModel(spawnPos, direction, rotation);
        Transform bullet = BulletSpawner.Instance.Spawn(BulletSpawner.BulletOne, bulletModel.GetSpawnPos(), bulletModel.GetRotation());
        this.bulletFly = bullet.GetComponentInChildren<BulletFly>();
        this.bulletFly.SetDirection(bulletModel.GetDirection());
        return bullet;
    }

    public virtual void BulletDespawn(Transform bulletObject)
    {
        BulletSpawner.Instance.Despawn(bulletObject);
    }


}
