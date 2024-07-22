using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordDespawn : DespawnByDistance
{
    protected override void DespawnObject()
    {
        ShipController.Instance.ShipShooting.ResetTarget();
        WordSpawner.Instance.Despawn(transform.parent);
    }
   
}
