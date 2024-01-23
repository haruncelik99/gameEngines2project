using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject baslikImg;
    [SerializeField] private GameObject butonlarPanel, optionsPanel;

    [SerializeField] private string levelName;

    [SerializeField] private AudioClip butonClip, panelAcmaClip;

    private Slider backMusicSlider, sfxSlider;

    private void Awake()
    {
        backMusicSlider = GameObject.Find("BackMusicSlider").GetComponent<Slider>();
        sfxSlider = GameObject.Find("SFXSlider").GetComponent<Slider>();
    }

    private void Start()
    {
        

        if (backMusicSlider)
        {
            if (!PlayerPrefs.HasKey("BackMusic"))
            {
                PlayerPrefs.SetFloat("BackMusic",.2f);
                backMusicSlider.value = PlayerPrefs.GetFloat("BackMusic");
            }
            else
            {
                backMusicSlider.value = PlayerPrefs.GetFloat("BackMusic");
            }
        }
        
        if (sfxSlider)
        {
            if (!PlayerPrefs.HasKey("SFXVolume"))
            {
                PlayerPrefs.SetFloat("SFXVolume",.5f);
                sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
            }
            else
            {
                sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
            }
        }
        
        StartCoroutine(ObjeleriAcRoutine());
        
        
    }

    IEnumerator ObjeleriAcRoutine()
    {
        baslikImg.GetComponent<CanvasGroup>().DOFade(1, .5f);
        yield return new WaitForSeconds(.5f);

        butonlarPanel.GetComponent<RectTransform>().DOAnchorPosY(0, .5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(.2f);

        butonlarPanel.transform.GetChild(0).GetComponent<CanvasGroup>().DOFade(1, .5f);
        butonlarPanel.transform.GetChild(0).GetComponent<RectTransform>().DOAnchorPosX(-50, .4f).From()
            .SetEase(Ease.OutBack);
        
        yield return new WaitForSeconds(.3f);
        
        butonlarPanel.transform.GetChild(1).GetComponent<CanvasGroup>().DOFade(1, .5f);
        butonlarPanel.transform.GetChild(1).GetComponent<RectTransform>().DOAnchorPosX(-50, .4f).From()
            .SetEase(Ease.OutBack);
        
        yield return new WaitForSeconds(.3f);
        
        butonlarPanel.transform.GetChild(2).GetComponent<CanvasGroup>().DOFade(1, .5f);
        butonlarPanel.transform.GetChild(2).GetComponent<RectTransform>().DOAnchorPosX(-50, .4f).From()
            .SetEase(Ease.OutBack);
        
        



    }

    public void OptionsPaneliAc()
    {
        
        butonlarPanel.GetComponent<RectTransform>().DOAnchorPosY(700, .5f);
        optionsPanel.GetComponent<RectTransform>().DOAnchorPosY(0, .5f);
        AudioSource.PlayClipAtPoint(panelAcmaClip,Camera.main.transform.position);
    }
    
    public void OptionsPaneliKapat()
    {
        butonlarPanel.GetComponent<RectTransform>().DOAnchorPosY(0, .5f);
        optionsPanel.GetComponent<RectTransform>().DOAnchorPosY(700, .5f);
        AudioSource.PlayClipAtPoint(panelAcmaClip,Camera.main.transform.position);
    }

    public void OyundanCik()
    {
        Application.Quit();
        AudioSource.PlayClipAtPoint(butonClip,Camera.main.transform.position);
    }

    public void OyunaBasla()
    {
        AudioSource.PlayClipAtPoint(butonClip,Camera.main.transform.position);
        SceneManager.LoadScene(levelName);
    }

    public void BackVolumeDegistirFNC()
    {
        if (backMusicSlider && SoundManager.instance)
        {
            PlayerPrefs.SetFloat("BackMusic",backMusicSlider.value);
            SoundManager.instance.BackMusicSesAyari();
        }
    }
    
    public void SFXVolumeDegistirFNC()
    {
        if (sfxSlider)
        {
            PlayerPrefs.SetFloat("SFXVolume",sfxSlider.value);
        }
    }
}
