using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class  ExtensionMethods 
{
     public static void SetStartColor(this ParticleSystem psys, Color c)
    {
        var m = psys.main;
        m.startColor = c;
    }
}
