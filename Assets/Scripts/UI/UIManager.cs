using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private Image healthFillImg;
    [SerializeField] private Image zirhFillImg;

    [SerializeField] private TextMeshProUGUI healthTxt, zirhTxt;

    private void Awake()
    {
        instance = this;
    }

    public void StartHealthFNC(int toplamCan, int gecerliCan, int toplamZirh, int gecerliZirh)
    {
        healthFillImg.fillAmount = (float) gecerliCan / toplamCan;
        zirhFillImg.fillAmount = (float)gecerliZirh / toplamZirh;

        healthTxt.text = gecerliCan + "/" + toplamCan;
        zirhTxt.text = gecerliZirh + "/" + toplamZirh;
    }

    public void UpdateHealthFNC(int toplamCan, int gecerliCan, int toplamZirh, int gecerliZirh)
    {
        healthFillImg.DOFillAmount((float)gecerliCan / toplamCan, .3f);
        zirhFillImg.DOFillAmount((float)gecerliZirh / toplamZirh, .3f);

        

        healthTxt.text = gecerliCan + "/" + toplamCan;
        zirhTxt.text = gecerliZirh + "/" + toplamZirh;
    }
}
