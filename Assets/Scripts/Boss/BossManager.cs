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

    [Header("Düzenli Mermi Ayarlari")] 
    [SerializeField] private float mermiHizi = 10f;
    [SerializeField] private int mermiAdet;
    [SerializeField] private float ikiMermiArasiSure;
    [SerializeField] private float gecikmeZamani = 1f;

    private bool atesEtsinmi = false;

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

    void MermiFirlatFNC()
    {
        if(!PlayerHareketController.instance.gameObject.activeInHierarchy)
            return;
        
        
        if (!atesEtsinmi)
        {
            StartCoroutine(DuzenliAtesEtRoutine());
        }
        
    }
    

    IEnumerator DuzenliAtesEtRoutine()
    {
        atesEtsinmi = true;

        for (int i = 0; i < mermiAdet; i++)
        {
            Vector2 hareketYonu = PlayerHareketController.instance.transform.position - transform.position;

            BossBullet yeniMermi = ObjectPool.instance.BossMermiCikarFNC();
            yeniMermi.transform.position = transform.position;
            yeniMermi.transform.right = hareketYonu;
            yeniMermi.MermiHiziniDegistir(mermiHizi);
            yeniMermi.gameObject.SetActive(true);

            yield return new WaitForSeconds(ikiMermiArasiSure);
        }
        

        yield return new WaitForSeconds(gecikmeZamani);
        atesEtsinmi = false;
    }
    
    
    
    
    

    void HareketEtFNC()
    {
        if (PlayerHareketController.instance.gameObject.activeInHierarchy)
        {
            transform.position = Vector3.MoveTowards(transform.position, hedefPos.position, harekethizi * Time.deltaTime);

            if (Vector3.Distance(transform.position, hedefPos.position) < .1f && hareketEtsinmi)
            {
                hareketEtsinmi = false;
                transform.position = hedefPos.position;
                StartCoroutine(AzBekleHareketEtRouitine());
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            anim.Play("UpDownAnim");
        }
        
        
        
    }
    
    
    

    IEnumerator AzBekleHareketEtRouitine()
    {
        anim.Play("UpDownAnim");
        MermiFirlatFNC();
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
