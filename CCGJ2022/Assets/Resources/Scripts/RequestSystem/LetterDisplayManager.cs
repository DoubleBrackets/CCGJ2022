using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LetterDisplayManager : BaseInteractable
{
    public static LetterDisplayManager instance;

    private bool isDisplaying;

    public GameObject displayObject;
    public TMPro.TextMeshProUGUI displayText;

    private void Awake()
    {
        instance = this;
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
