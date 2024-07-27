using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordType : WMonobehaviour
{
    [SerializeField] protected bool isSentence = false;
    public bool IsSentence => isSentence;

    public virtual void SetIsSentence()
    {
        isSentence = true;
    }
    public virtual void SetIsWord()
    {
        isSentence = false;
    }
}
