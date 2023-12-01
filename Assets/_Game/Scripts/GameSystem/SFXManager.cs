using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    [System.Serializable]public struct SFXSource
    {
        public string name;
        public AudioSource audioSource;
    }
    public static SFXManager Instance;

    public List<SFXSource> sFXSourcesList;

    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlaySound(string soundSourceName)
    {
        foreach (SFXSource source in sFXSourcesList)
        {
            if (source.name == soundSourceName)
            {

                source.audioSource.Play();
                return;
            }
        }
        Debug.LogError("can't find sound");
    }
    
    public void StopAllSound()
    {
        foreach (SFXSource source in sFXSourcesList)
        {
            if (source.audioSource.isPlaying)
            {
                source.audioSource.Stop();
            }
        }
    }
}
