using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipAbstract : WMonobehaviour
{
    [SerializeField] protected ShipController shipController;
    public ShipController ShipController { get => shipController; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipController();
    }
    protected virtual void LoadShipController()
    {
        if (this.shipController != null) return;
        this.shipController = transform.parent.GetComponent<ShipController>();
        Debug.Log(transform.name + ": LoadShipController", gameObject);
    }
}
