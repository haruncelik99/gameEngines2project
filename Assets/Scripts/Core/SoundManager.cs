
using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;


    [SerializeField] private AudioSource backSource;
    [SerializeField] private AudioClip[] backClips;

    private AudioClip rastgeleClip;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        rastgeleClip = RastgeleClipSec(backClips);

        if (rastgeleClip)
        {
            BackGroundMusicCal(rastgeleClip);
        }
    }

    void BackGroundMusicCal(AudioClip clip)
    {
        if (backSource)
        {
            backSource.clip = clip;
            backSource.Play();
        }
    }

    AudioClip RastgeleClipSec(AudioClip[] clips)
    {
        AudioClip _rastgeleClip = clips[Random.Range(0, clips.Length)];
        return _rastgeleClip;
    }
}
