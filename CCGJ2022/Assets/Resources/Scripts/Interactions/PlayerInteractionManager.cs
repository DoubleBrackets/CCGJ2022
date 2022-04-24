using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerInteractionManager : MonoBehaviour
{

    public void Awake()
    {
        var interactables = GameObject.FindObjectsOfType<BaseInteractable>();
        foreach(var interactable in interactables)
        {
            interactable.InteractionContext = this;
        }
    }


    public Action<Vector2,BaseInteractable> OnMouseDown;
    public Action<Vector2,BaseInteractable> OnMouseUp;
}
