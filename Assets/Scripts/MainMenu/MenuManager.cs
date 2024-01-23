using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject baslikImg;
    [SerializeField] private GameObject butonlarPanel, optionsPanel;

    [SerializeField] private string levelName;

    [SerializeField] private AudioClip butonClip, panelAcmaClip;

    private void Start()
    {
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
    
}
