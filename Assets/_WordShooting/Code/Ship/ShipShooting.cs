using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipShooting : ShipAbstract
{
    private static ShipShooting instance;
    public static ShipShooting Instance { get => instance; }
    protected override void Awake()
    {
        base.Awake();
        if (ShipShooting.instance != null) Debug.LogError("Only 1 ShipShooting allow to exist");
        ShipShooting.instance = this;
    }

    [SerializeField] protected int currentCharIndex = 0;
    [SerializeField] protected string currentTarget = "";
    [SerializeField] protected Transform modelTrans;
    protected TextMeshPro targetTextComponent;

    private List<Transform> bullets = new List<Transform>();

    protected virtual void Update()
    {
        this.CheckKeyInput();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.GetModelTrans();
    }

    protected virtual void GetModelTrans()
    {
        modelTrans = this.shipCtrl.Model.transform;
    }

    protected virtual void CheckKeyInput()
    {
        Transform targetTextTransform = this.shipCtrl.LookAtTarget.GetShortestDistance();
        if (targetTextTransform != null)
        {
            if (this.targetTextComponent == null)
            {
                this.targetTextComponent = targetTextTransform.GetComponentInChildren<TextMeshPro>();
                if (this.targetTextComponent != null)
                {
                    this.currentTarget = this.targetTextComponent.text.ToLower();
                    this.currentCharIndex = 0;
                }
            }

            if (Input.anyKeyDown && !string.IsNullOrEmpty(Input.inputString))
            {
                char typedChar = Input.inputString.ToLower()[0];

                if (this.currentCharIndex < this.currentTarget.Length && typedChar == this.currentTarget[this.currentCharIndex])
                {
                    this.currentCharIndex++;
                    this.Shooting();
                    HighlightTypedText(this.targetTextComponent);

                    if (this.currentCharIndex >= this.currentTarget.Length)
                    {
                        Transform smoke = FXSpawner.Instance.Spawn(FXSpawner.smokeOne, targetTextTransform.position, targetTextTransform.rotation);
                        smoke.gameObject.SetActive(true);
                        WordSpawner.Instance.Despawn(targetTextTransform);
                        this.ResetTarget();
                    }
                }
            }
        }
    }

    protected virtual void HighlightTypedText(TextMeshPro targetTextComponent)
    {
        targetTextComponent.text = "<color=green>" + currentTarget.Substring(0, this.currentCharIndex) + "</color>" + this.currentTarget.Substring(this.currentCharIndex);
    }

    public virtual void ResetTarget()
    {
        this.currentCharIndex = 0;
        this.targetTextComponent = null;
        this.currentTarget = "";

        foreach (var bullet in bullets)
        {
            BulletSpawner.Instance.Despawn(bullet.transform);
        }
        bullets.Clear();
    }

    protected virtual void Shooting()
    {
        Vector3 spawnPos = modelTrans.position;
        Quaternion rotation = modelTrans.parent.rotation;
        Transform newPrefab = BulletSpawner.Instance.Spawn(BulletSpawner.BulletOne, spawnPos, rotation);
        if (newPrefab == null) return;
        newPrefab.gameObject.SetActive(true);
        
        bullets.Add(newPrefab);

        Vector3 direction = GetDirection();
        BulletFly bulletFly = newPrefab.GetComponentInChildren<BulletFly>();
        if (bulletFly != null)
        {
            bulletFly.SetDirection(direction);
        }
    }

    public virtual Vector3 GetDirection()
    {
        Transform targetTextTransform = this.shipCtrl.LookAtTarget.GetShortestDistance();
        if (targetTextTransform == null) return Vector3.zero;
        Vector3 spawnPos = modelTrans.position;
        Vector3 targetPos = targetTextTransform.position;
        Vector3 direction = (targetPos - spawnPos).normalized;
        return direction;
    }
}
