using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public static void PlayOneShot(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
