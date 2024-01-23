

using UnityEngine;



public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;


    [SerializeField] private AudioSource backSource;
    [SerializeField] private AudioClip[] backClips;

    private AudioClip rastgeleClip;

    [SerializeField] private AudioSource[] sesEfektleri;


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

    public void SesEfektiCikar(int hangiSes)
    {
        if (sesEfektleri[hangiSes])
        {
            sesEfektleri[hangiSes].Stop();
            sesEfektleri[hangiSes].Play();
        }
    }
    
    public void KarisikSesEfektiCikar(int hangiSes)
    {
        if (sesEfektleri[hangiSes])
        {
            sesEfektleri[hangiSes].Stop();
            sesEfektleri[hangiSes].pitch = Random.Range(0.8f, 1.2f);
            sesEfektleri[hangiSes].Play();
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

    public void BackMusicSesAyari()
    {
        backSource.volume = PlayerPrefs.GetFloat("BackMusic");
    }
}
