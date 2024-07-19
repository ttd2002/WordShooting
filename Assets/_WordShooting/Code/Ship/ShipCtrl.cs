using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipCtrl : WMonobehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected LookAtTarget lookAtTarget;
    public LookAtTarget LookAtTarget { get => lookAtTarget; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadLookAtTarget();

    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadLookAtTarget()
    {
        if (this.lookAtTarget != null) return;
        this.lookAtTarget = transform.GetComponentInChildren<LookAtTarget>();
        Debug.Log(transform.name + ": LoadLookAtTarget", gameObject);
    }
}
