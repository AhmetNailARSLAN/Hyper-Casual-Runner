using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private AudioSource _audioSource;
    [SerializeField] AudioClip finishSound;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip collectSound;
    [SerializeField] AudioClip breakSound;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayFinishSound()
    {
        _audioSource.PlayOneShot(finishSound);
    }

    public void PlayCrashSound()
    {
        _audioSource.PlayOneShot(crashSound);
    }

    public void PlayCollectSound()
    {
        _audioSource.PlayOneShot(collectSound);
    }

    public void PlayBreakSound()
    {
        _audioSource.PlayOneShot(breakSound);
    }

}
