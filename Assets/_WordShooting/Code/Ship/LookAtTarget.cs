using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : ShipAbstract
{
    [SerializeField] protected List<Transform> textObjects;

    protected virtual void Update()
    {
        this.FillTextObjects();
        this.RemoveTextObject();
        Transform closestTextObject = this.GetShortestDistance();
        if (closestTextObject != null)
        {
            this.LookAtToTarget(closestTextObject);
        }
    }

    protected virtual void FillTextObjects()
    {
        foreach (Transform textObject in WordSpawner.Instance.GetHolder())
        {
            if (textObject.gameObject.activeSelf && !textObjects.Contains(textObject))
            {
                this.textObjects.Add(textObject);
            }
        }
    }

    protected virtual void RemoveTextObject()
    {
        List<Transform> objectsToRemove = new List<Transform>();

        foreach (Transform textObject in textObjects)
        {
            if (!textObject.gameObject.activeSelf)
            {
                objectsToRemove.Add(textObject);
            }
        }

        foreach (Transform textObject in objectsToRemove)
        {
            textObjects.Remove(textObject);
        }
    }

    public virtual Transform GetShortestDistance()
    {
        Transform closestTextObject = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Transform textObject in textObjects)
        {
            Vector3 despawnPoint = new Vector3(textObject.position.x, textObject.position.y - 8.23f, textObject.position.z);
            float distance = Vector3.Distance(textObject.position, despawnPoint);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestTextObject = textObject;
            }
        }
        return closestTextObject;
    }

    protected virtual void LookAtToTarget(Transform closestTextObject)
    {
        Vector3 direction = closestTextObject.position - this.shipCtrl.Model.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.shipCtrl.Model.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
    }
}
