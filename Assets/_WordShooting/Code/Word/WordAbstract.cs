using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordAbstract : WMonobehaviour
{
    [SerializeField] protected WordController wordController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWordController();
    }

    protected virtual void LoadWordController()
    {
        if (this.wordController != null) return;
        this.wordController = GetComponent<WordController>();
        Debug.Log(transform.name + ": LoadWordController", gameObject);
    }
}
