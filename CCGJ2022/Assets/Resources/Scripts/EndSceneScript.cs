using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneScript : MonoBehaviour
{

    void Update()
    {
        if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            FadeManagerScript.instance.FadeOut();
        }
    }
}
