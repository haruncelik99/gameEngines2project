
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] private Image fillImg;
    [SerializeField] private GameObject damageEffect;
    [SerializeField] private GameObject deathEffect;

    [SerializeField] private float mermiTepkiGucu = 3f;

    [SerializeField] private int maxCan = 100;
    private int gecerliCan;

    private KnockBack knockBack;

    private void Awake()
    {
        knockBack = GetComponent<KnockBack>();
    }

    private void Start()
    {
        gecerliCan = maxCan;

        fillImg.fillAmount = maxCan;
        

    }

    public void HasarAlFNC(int hasarMiktar�)
    {
        gecerliCan -= hasarMiktar�;

        fillImg.DOFillAmount((float)gecerliCan / maxCan, .5f);

        Instantiate(damageEffect, transform.position, Quaternion.identity);
        knockBack.GeriTepkiFNC(PlayerHareketController.instance.transform, mermiTepkiGucu);

        if (gecerliCan <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }

    }

}
