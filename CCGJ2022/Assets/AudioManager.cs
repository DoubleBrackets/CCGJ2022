using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    private static AudioSource source;
    [System.Serializable]
    public struct SFX
    {
        public string name;
        public AudioClip clip;
    }

    [SerializeField]
    public List<SFX> clips;
    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public static void PlayOneShot(string name)
    {
        var search = instance.clips.Find(x => x.name == name);
        if(search.clip != null)
            source.PlayOneShot(search.clip);
    }
}
