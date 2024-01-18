using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int toplamPuan;
    public int coinAdet;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        toplamPuan = 0;
        coinAdet = 0;
    }

    public void PuanArtir(int gelenPuan)
    {
        toplamPuan += gelenPuan;
        UIManager.instance.PuaniYazdir(toplamPuan);
    }

    public void CoinArtir(int gelenAdet)
    {
        coinAdet++;
        UIManager.instance.CoinAdetYazdir(coinAdet);
    }

}
