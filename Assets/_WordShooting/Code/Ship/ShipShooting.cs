using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipShooting : ShipAbstract
{
    [SerializeField] protected int currentCharIndex = 0;
    [SerializeField] protected string currentTarget = "";
    protected TextMeshPro targetTextComponent;
    private List<Transform> bullets = new List<Transform>();

    public virtual void CheckKeyInput(Transform targetTextTransform)
    {
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
                        this.FinishTextEffect(targetTextTransform);
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

        foreach (Transform bullet in bullets)
        {
            BulletSpawner.Instance.Despawn(bullet.transform);
        }
        this.bullets.Clear();
    }

    protected virtual void Shooting()
    {
        Vector3 spawnPos = this.shipController.GetModelTransform().position;
        Quaternion rotation = this.shipController.GetModelTransform().parent.rotation;
        Vector3 direction = GetDirection();
        Transform newPrefab = BulletController.Instance.SpawnBullet(spawnPos, rotation,direction);
        if (newPrefab == null) return;
        newPrefab.gameObject.SetActive(true);

        this.bullets.Add(newPrefab);
    }

    public virtual Vector3 GetDirection()
    {
        Transform targetTextTransform = this.shipController.LookAtTarget.GetShortestDistance();
        if (targetTextTransform == null) return Vector3.zero;
        Vector3 spawnPos = this.shipController.GetModelTransform().position;
        Vector3 targetPos = targetTextTransform.position;
        Vector3 direction = (targetPos - spawnPos).normalized;
        return direction;
    }
    protected virtual void FinishTextEffect(Transform targetTextTransform)
    {
        FXController.Instance.SpawnFXSmoke(targetTextTransform.position, targetTextTransform.rotation);
    }
}
