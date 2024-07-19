using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMonobehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponent();
        this.ResetValue();

    } 
    protected virtual void Awake()
    {
        this.LoadComponent();
    }
    protected virtual void LoadComponent()
    {
        //for override
    }
    protected virtual void ResetValue()
    {
        //for override
    }
    protected virtual void Start()
    {
        //for override
    }
    protected virtual void OnEnable()
    {

    }
}
