using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour
{
    private PlayerInteractionManager interactionContext;

    public PlayerInteractionManager InteractionContext
    {
        get => interactionContext;
        set => interactionContext = value;
    }

}
