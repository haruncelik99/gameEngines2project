using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : MonoBehaviour
{
    [SerializeField] private float harekethizi = 10f;

    [SerializeField] private Transform[] bombPositions;

    private Transform hedefPos;

    [SerializeField] private float beklemeSuresi = 2f;

    private bool hareketEtsinmi = true;

    private int kacinciPos;

    private void Start()
    {
        YeniHedefOlusturFNC();
    }


    private void Update()
    {
        if(!hareketEtsinmi)
            return;
        transform.position = Vector3.MoveTowards(transform.position, hedefPos.position, harekethizi * Time.deltaTime);

        if (Vector3.Distance(transform.position, hedefPos.position) < .1f && hareketEtsinmi)
        {
            hareketEtsinmi = false;
            StartCoroutine(AzBekleHareketEtRouitine());
        }
            
        
    }

    IEnumerator AzBekleHareketEtRouitine()
    {
        YeniHedefOlusturFNC();
        yield return new WaitForSeconds(beklemeSuresi);
        hareketEtsinmi = true;
    }

    void YeniHedefOlusturFNC()
    {
        hedefPos = bombPositions[kacinciPos];

        kacinciPos++;

        if (kacinciPos >= bombPositions.Length)
            kacinciPos = 0;
    }
}
