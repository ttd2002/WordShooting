using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnExit : ButtonBase
{
    protected override void OnClick()
    {
        Time.timeScale = 0;
    }
}
