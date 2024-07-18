using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordFalling : WMonobehaviour
{
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.down;

    private void Update()
    {
        transform.parent.Translate(this.direction * this.speed * Time.deltaTime);
    }
}
