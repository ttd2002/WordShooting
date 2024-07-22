using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    private Vector3 spawnPos { get; set; }
    private Vector3 direction { get; set; }
    private Quaternion rotation { get; set; }
    public BulletModel(Vector3 spawnPos, Vector3 direction, Quaternion rotation)
    {
        this.spawnPos = spawnPos;
        this.direction = direction;
        this.rotation = rotation;
    }
    public BulletModel()
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
    public Vector3 GetDirection()
    {
        return this.direction;
    }
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
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
