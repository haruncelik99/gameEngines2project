
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.Mathematics;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] private Image fillImg;
    [SerializeField] private GameObject damageEffect;
    [SerializeField] private GameObject deathEffect;

    [SerializeField] private float mermiTepkiGucu = 3f;

    [SerializeField] private int maxCan = 100;
    private int gecerliCan;

    private KnockBack knockBack;

    [SerializeField] private bool bossMu;

    private void Awake()
    {
        knockBack = GetComponent<KnockBack>();
    }

    private void Start()
    {
        gecerliCan = maxCan;

        fillImg.fillAmount = maxCan;
        

    }

    public void HasarAlFNC(int hasarMiktari)
    {
        gecerliCan -= hasarMiktari;

        fillImg.DOFillAmount((float)gecerliCan / maxCan, .5f);

        Instantiate(damageEffect, transform.position, Quaternion.identity);

        if (knockBack)
        {
            knockBack.GeriTepkiFNC(PlayerHareketController.instance.transform, mermiTepkiGucu);
        }

        if (SoundManager.instance)
        {
            SoundManager.instance.SesEfektiCikar(1);
        }
        
        

        if (gecerliCan <= 0)
        {
            if (SoundManager.instance)
            {
                SoundManager.instance.SesEfektiCikar(2);
            
            }
            
            
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            if (GetComponent<DropManager>())
            {
                GetComponent<DropManager>().NesneyiBirakFNC();
            }
            
            gameObject.SetActive(false);

            if (bossMu)
            {
                UIManager.instance.KazandiPanelAc();
            }
        }

    }

}
