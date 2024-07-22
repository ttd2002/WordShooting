using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : WMonobehaviour
{
    private static ShipController instance;
    public static ShipController Instance { get => instance; }
    protected override void Awake()
    {
        base.Awake();
        if (ShipController.instance != null) Debug.LogError("Only 1 ShipController allow to exist");
        ShipController.instance = this;
    }

    [SerializeField] protected ShipModel model;
    public ShipModel Model { get => model; }

    [SerializeField] protected LookAtTarget lookAtTarget;
    public LookAtTarget LookAtTarget { get => lookAtTarget; }
    [SerializeField] protected ShipShooting shipShooting;
    public ShipShooting ShipShooting { get => shipShooting; }
    protected virtual void Update()
    {
        // Look at target
        this.GetTarget();
        // Shoot
        this.ShipShootingAtTarget();
    }
    public virtual void ShipShootingAtTarget()
    {
        this.shipShooting.CheckKeyInput(this.GetClosestTextObject());
    }
    protected virtual void GetTarget()
    {
        this.lookAtTarget.FillTextObjects();
        this.lookAtTarget.RemoveTextObject();
        Transform closestTextObject = this.GetClosestTextObject();
        if (closestTextObject != null)
        {
            this.lookAtTarget.LookAtToTarget(closestTextObject);
        }
    }
    protected virtual Transform GetClosestTextObject()
    {
        return this.lookAtTarget.GetShortestDistance();
    }

    // Load Component
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadLookAtTarget();
        this.LoadShipShooting();

    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.GetComponentInChildren<ShipModel>();
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadLookAtTarget()
    {
        if (this.lookAtTarget != null) return;
        this.lookAtTarget = transform.GetComponentInChildren<LookAtTarget>();
        Debug.Log(transform.name + ": LoadLookAtTarget", gameObject);
    }
    protected virtual void LoadShipShooting()
    {
        if (this.shipShooting != null) return;
        this.shipShooting = transform.GetComponentInChildren<ShipShooting>();
        Debug.Log(transform.name + ": LoadShipShooting", gameObject);
    }
    public virtual Transform GetModelTransform()
    {
        return this.model.transform;
    }
}
