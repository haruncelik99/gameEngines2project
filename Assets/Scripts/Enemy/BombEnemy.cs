using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BombEnemy : MonoBehaviour
{
    [SerializeField] private GameObject bombaPrefab;
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
        
        BombaOlusturFNC();
    }

    void YeniHedefOlusturFNC()
    {
        hedefPos = bombPositions[kacinciPos];

        kacinciPos++;

        if (kacinciPos >= bombPositions.Length)
            kacinciPos = 0;
    }

    void BombaOlusturFNC()
    {
        float rand = Random.value;

        if (rand < 1f)
        {
            GameObject bomba = Instantiate(bombaPrefab, transform.position, Quaternion.identity);
            StartCoroutine(bomba.GetComponent<BombaManager>().BombaPatlatFNC(bomba.transform));
        }
    }
}
