
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private Image healthFillImg;
    [SerializeField] private Image zirhFillImg;

    [SerializeField] private TextMeshProUGUI healthTxt, zirhTxt;

    [SerializeField] private TextMeshProUGUI toplamPuanTxt, coinAdetTxt;

    [SerializeField] private GameObject pausePanel;
    
    [SerializeField] private string levelName;
    
    [SerializeField] private AudioClip butonClip, panelAcmaClip;

    [HideInInspector]
    public bool oyunDurdumu;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        toplamPuanTxt.text = "0 P";
        coinAdetTxt.text = "0";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PausePanelAcKapat();
    }

    void PausePanelAcKapat()
    {
        if(GameManager.instance.gameOver)
            return;

        oyunDurdumu = !oyunDurdumu;

        if (pausePanel)
        {
            pausePanel.SetActive(oyunDurdumu);
            AudioSource.PlayClipAtPoint(panelAcmaClip,Camera.main.transform.position);
            Time.timeScale = (oyunDurdumu) ? 0 : 1;


        }
    }

    public void OyunaDonFNC()
    {
        if (pausePanel)
        {
            
            AudioSource.PlayClipAtPoint(butonClip,Camera.main.transform.position);
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
    }

    public void AnaMenuFNC()
    {
        AudioSource.PlayClipAtPoint(butonClip,Camera.main.transform.position);
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelName);
    }

    public void OyundanCikFNC()
    {
        AudioSource.PlayClipAtPoint(butonClip,Camera.main.transform.position);
        Application.Quit();
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
