
using System;
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

    [SerializeField] private TextMeshProUGUI toplamPuanTxt, coinAdetTxt;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        toplamPuanTxt.text = "0 P";
        coinAdetTxt.text = "0";
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

    public void PuaniYazdir(int gelenPuan)
    {
        toplamPuanTxt.text = gelenPuan.ToString() + "P";
    }

    public void CoinAdetYazdir(int gelenAdet)
    {
        coinAdetTxt.text = gelenAdet.ToString();
    }
}
