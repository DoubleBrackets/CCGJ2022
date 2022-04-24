using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInteractable : BaseInteractable
{
    private RequestScheduler scheduler;

    private void Awake()
    {
        scheduler = FindObjectOfType<RequestScheduler>();
    }

    public override void OnDragReleaseListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (heldInteractable == null || !IsInBounds(mousePos)) return;
        if (heldInteractable.GetType() == typeof(LetterInteractable))
        {
            var envelope = (LetterInteractable)heldInteractable;
            if(envelope.Opened && !envelope.isInitialRequestLetter)
            {
                //Burn the fool
                AudioManager.PlayOneShot("burn");
                Destroy(envelope.gameObject);
                if (scheduler.RequestsFinished())
                {
                    if(FindObjectOfType<LetterInteractable>() == null)
                    {
                        FadeManagerScript.instance.FadeOut();
                    }
                }
            }
        }
    }

}
 