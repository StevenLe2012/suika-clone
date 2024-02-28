using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    [SerializeField] private AudioClip DropSFX;
    [SerializeField] private AudioClip CombineSFX;
    
    private AudioSource sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        sfxSource = GetComponent<AudioSource>();
    }

    public void PlayDropSFX()
    {
        sfxSource.PlayOneShot(DropSFX);
    }
    
    public void PlayCombineSFX()
    {
        sfxSource.PlayOneShot(CombineSFX);
    }
}