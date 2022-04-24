using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FadeManagerScript : MonoBehaviour
{
    public static FadeManagerScript instance;
    public int nextSceneIndex;

    public float fadeTime;

    public Image fadeImage;

    private void Awake()
    {
        instance = this;
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        Color c = fadeImage.color;
        c.a = 1;
        fadeImage.color = c;
        yield return new WaitForSeconds(2f);
        float timer = 0f;
        while(timer < fadeTime)
        {
            timer += Time.deltaTime;
            c = fadeImage.color;
            c.a = 1 - Mathf.Min(1,Mathf.Pow(timer / fadeTime,2f));
            fadeImage.color = c;
            yield return new WaitForEndOfFrame();
        }
    }

    private bool inFadeOut = false;
    public void FadeOut()
    { 
        if (inFadeOut) return;
        inFadeOut = true;
        StartCoroutine(Corout_FadeOut());
    }
    private IEnumerator Corout_FadeOut()
    {
        yield return new WaitForSeconds(3f);
        float timer = 0f;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            Color c = fadeImage.color;
            c.a = Mathf.Min(1, Mathf.Pow(timer / fadeTime, 2f));
            fadeImage.color = c;
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

}
