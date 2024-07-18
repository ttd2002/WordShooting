using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 15f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Vector3 pointPos;

    protected override bool CanDespawn()
    {
        this.GetDespawnPos();
        this.distance = Vector3.Distance(transform.position, this.pointPos);
        if (this.distance > this.disLimit) return true;
        return false;
    }
    protected virtual void GetDespawnPos()
    {
        this.pointPos = transform.parent.position;
        this.pointPos.y = 6;
    }

    
}
