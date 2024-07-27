using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TextTime : TextBase
{
    protected override void FixedUpdate()
    {
        this.UpdateTime();
    }
    protected virtual void UpdateTime()
    {
        
        this.text.SetText(TimeManager.Instance.GameDuration);
        //if(TimeManager.Instance.EndGame()) this.text.color = Color.red;
    }
}
