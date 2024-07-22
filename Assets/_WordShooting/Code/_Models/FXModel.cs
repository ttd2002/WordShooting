using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXModel
{
    private Vector3 spawnPos { get; set; }
    private Quaternion rotation { get; set; }
    private string prefabName { get; set; }

    public FXModel(Vector3 spawnPos, Quaternion rotation, string prefabName)
    {
        this.spawnPos = spawnPos;
        this.rotation = rotation;
        this.prefabName = prefabName;
    }
    public FXModel()
    {

    }
    public Vector3 GetSpawnPos()
    {
        return this.spawnPos;
    }

    public void SetSpawnPos(Vector3 spawnPos)
    {
        this.spawnPos = spawnPos;
    }
    public string GetPrefabName()
    {
        return this.prefabName;
    }
    public void SetPrefabName(string prefabName)
    {
        this.prefabName = prefabName;
    }
    public Quaternion GetRotation()
    {
        return this.rotation;
    }
    public void SetRotation(Quaternion rotation)
    {
        this.rotation = rotation;
    }
}
