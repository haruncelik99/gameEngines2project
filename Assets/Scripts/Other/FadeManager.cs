using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeManager : MonoBehaviour
{
    private Image fadeImg;

    private void Awake()
    {
        fadeImg = GetComponent<Image>();
    }

    private void Start()
    {
        StartCoroutine(ALphaKapatRouitine());
    }

    IEnumerator ALphaKapatRouitine()
    {
        fadeImg.GetComponent<CanvasGroup>().DOFade(0,1f);
        yield return new WaitForSeconds(2f);
    }

    public IEnumerator AlphaAcRouitine()
    {
        fadeImg.GetComponent<CanvasGroup>().DOFade(1,1f);
        yield return new WaitForSeconds(2f);
    }
}
