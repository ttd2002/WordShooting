using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipAbstract : WMonobehaviour
{
    [SerializeField] protected ShipCtrl shipCtrl;
    public ShipCtrl ShipCtrl { get => shipCtrl; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShipCtrl();
    }
    protected virtual void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + ": LoadShipCtrl", gameObject);
    }
}
