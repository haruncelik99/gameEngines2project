using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private int toplamCan = 10;
    private int gecerliCan;

    [SerializeField] private int toplamZirh = 5;
    private int gecerliZirh;

    [SerializeField] private GameObject playerDamageEffect,playerDeathEffect;



    private bool zirhVarmi;

    private void Start()
    {
        zirhVarmi = true;

        gecerliCan = toplamCan;
        gecerliZirh = toplamZirh;

        UIManager.instance.StartHealthFNC(toplamCan, gecerliCan, toplamZirh, gecerliZirh);
    }

   

    public void HasarAlFNC(int hasarMiktari)
    {
        if (gecerliCan <= 0)
            return;

        Instantiate(playerDamageEffect, transform.position, Quaternion.identity);

        if (zirhVarmi)
        {
            gecerliZirh -= hasarMiktari;

            UIManager.instance.UpdateHealthFNC(toplamCan, gecerliCan, toplamZirh, gecerliZirh);

            if (gecerliZirh <= 0)
            {
                zirhVarmi = false;
            }
            return;
        }

        gecerliCan -= hasarMiktari;

        UIManager.instance.UpdateHealthFNC(toplamCan, gecerliCan, toplamZirh, gecerliZirh);

        if (gecerliCan <= 0)
        {
            PlayerCanVerdi();
        }
    }

    void PlayerCanVerdi()
    {
        Instantiate(playerDeathEffect, transform.position, Quaternion.identity);
        this.gameObject.SetActive(false);
    }
}
