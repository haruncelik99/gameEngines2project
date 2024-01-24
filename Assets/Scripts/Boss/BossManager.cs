using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BossManager : MonoBehaviour
{
    
    [SerializeField] private float harekethizi = 10f;

    [SerializeField] private Transform[] positions;

    private Transform hedefPos;

    [SerializeField] private float beklemeSuresi = 2f;

    private bool hareketEtsinmi = true;

    private int kacinciPos;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        YeniHedefOlusturFNC();
    }


    private void Update()
    {
        if(!hareketEtsinmi)
            return;
        
        HareketEtFNC();
        
        
        
    }

    void HareketEtFNC()
    {
        transform.position = Vector3.MoveTowards(transform.position, hedefPos.position, harekethizi * Time.deltaTime);

        if (Vector3.Distance(transform.position, hedefPos.position) < .1f && hareketEtsinmi)
        {
            hareketEtsinmi = false;
            transform.position = hedefPos.position;
            StartCoroutine(AzBekleHareketEtRouitine());
        }
    }
    
    
    

    IEnumerator AzBekleHareketEtRouitine()
    {
        anim.Play("UpDownAnim");
        
        yield return new WaitForSeconds(beklemeSuresi);
        hareketEtsinmi = true;
        YeniHedefOlusturFNC();
        
        
    }

    void YeniHedefOlusturFNC()
    {
        hedefPos = positions[kacinciPos];

        if (hedefPos.position.x > transform.position.x)
        {
            anim.Play("RightAnim");
        }else if (hedefPos.position.x < transform.position.x)
        {
            anim.Play("LeftAnim");
        }

        kacinciPos++;

        if (kacinciPos >= positions.Length)
            kacinciPos = 0;
    }

    
}
