using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScreenMode:MonoBehaviour
{
    private static Color screenColor; 
    
    void Awake()
    {
        screenColor = Camera.main.backgroundColor;
    }

    public static void SwitchDesktopPetMode(bool _isflag)
    {
        Camera.main.backgroundColor = _isflag ? Color.black : screenColor;
    }
    
}
