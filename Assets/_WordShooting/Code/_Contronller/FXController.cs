using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXController : WMonobehaviour
{
    private static FXController instance;
    public static FXController Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (FXController.instance != null) Debug.LogError("Only 1 FXController allow to exist");
        FXController.instance = this;
    }

    public virtual void SpawnFXImpact(Vector3 position, Quaternion rotation)
    {
        this.SpawnFX(this.GetImpactFXName(), position, rotation);
    }

    public virtual void SpawnFXSmoke(Vector3 position, Quaternion rotation)
    {
        this.SpawnFX(this.GetSmokeFXName(), position, rotation);

    }
    protected virtual void SpawnFX(string name, Vector3 position, Quaternion rotation)
    {
        FXModel fXModel = new FXModel(position, rotation, name);
        Transform fx = FXSpawner.Instance.Spawn(fXModel.GetPrefabName(), fXModel.GetSpawnPos(), fXModel.GetRotation());
        fx.gameObject.SetActive(true);
    }
    protected virtual string GetImpactFXName()
    {
        return FXSpawner.impactOne;
    }
    protected virtual string GetSmokeFXName()
    {
        return FXSpawner.smokeOne;
    }
}
