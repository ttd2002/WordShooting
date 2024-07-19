using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : WMonobehaviour
{
    [SerializeField] protected float moveSpeed = 10f;
    private Vector3 direction;

    private void Update()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }
}
