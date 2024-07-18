using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordDespawn : DespawnByDistance
{
    protected override void DespawnObject()
    {
        ShipShooting.Instance.ResetTarget();
        WordSpawner.Instance.Despawn(transform.parent);
    }
   
}
