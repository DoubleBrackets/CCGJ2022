using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LetterDisplayManager : BaseInteractable
{
    public static LetterDisplayManager instance;

    //dont ask
    private RequestScheduler scheduler;
    private OwlSystem owlSystem;

    private bool isDisplaying;

    public GameObject displayObject;
    public TMPro.TextMeshProUGUI displayText;

    private void Awake()
    {
        instance = this;
        scheduler = FindObjectOfType<RequestScheduler>();
        owlSystem = FindObjectOfType<OwlSystem>();
    }


    public override void OnClickDownListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if(isDisplaying)
        {
            StopDisplaying();
        }
    }

    private void StopDisplaying()
    {
        displayObject.SetActive(false);
        isDisplaying = false;
        //check for end
        if(scheduler.RequestsFinished() && owlSystem.IsOwlSystemEmpty())
        {
            var find = scheduler.gameObject.GetComponentsInChildren<LetterInteractable>();
            foreach(var found in find)
            {
                if (!found.Opened || found.isInitialRequestLetter)
                    return;
            }
            FadeManagerScript.instance.FadeOut();
        }
    }

    public bool TryDisplay(string text)
    {
        if (isDisplaying)
            return false;
        isDisplaying = true;
        displayObject.SetActive(true);
        displayText.text = text;
        return true;
    }
}
