using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [Header("Mermiler Pools")]
    [SerializeField] private Transform mermiHolder;
    [SerializeField] private PlayerBullet playerBullet;
    public List<PlayerBullet> playerBulletList = new List<PlayerBullet>();
    [SerializeField]
    private int playerBulletAdet = 40;

    [Header("Enemy Mermiler Pools")]
    [SerializeField] private Transform enemyMermiHolder;
    [SerializeField] private EnemyBullet enemyBullet;
    public List<EnemyBullet> enemyBulletList = new List<EnemyBullet>();
    [SerializeField]
    private int enemyBulletAdet = 30;





    [Header("DuvarMermiPools")]
    [SerializeField] private Transform duvarMermiEfectHolder;
    [SerializeField] private GameObject duvarEfekt;
    public List<GameObject> duvarMermiEfectList = new List<GameObject>();
    [SerializeField]
    private int duvarEffectAdet = 15;
    
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < playerBulletAdet; i++)
        {
            PlayerBullet bullet = Instantiate(playerBullet);
            bullet.gameObject.SetActive(false);
            bullet.gameObject.transform.SetParent(mermiHolder);
            playerBulletList.Add(bullet);

        }

        for (int i = 0; i < enemyBulletAdet; i++)
        {
            EnemyBullet enemy_bullet = Instantiate(enemyBullet);
            enemy_bullet.gameObject.SetActive(false);
            enemy_bullet.gameObject.transform.SetParent(enemyMermiHolder);
            enemyBulletList.Add(enemy_bullet);

        }



        for (int i = 0; i < duvarEffectAdet; i++)
        {
            GameObject duvar_Efecti = Instantiate(duvarEfekt);
            duvar_Efecti.gameObject.SetActive(false);
            duvar_Efecti.gameObject.transform.SetParent(duvarMermiEfectHolder);
            duvarMermiEfectList.Add(duvar_Efecti);

        }
    }
    public PlayerBullet MermiCikarFNC()
    {
        for (int i = 0; i < playerBulletList.Count; i++)
        {
            if (!playerBulletList[i].gameObject.activeInHierarchy)
            {
                return playerBulletList[i];
            }
        }

        return null;
    }

    public EnemyBullet EnemyMermiCikarFNC()
    {
        for (int i = 0; i < enemyBulletList.Count; i++)
        {
            if (!enemyBulletList[i].gameObject.activeInHierarchy)
            {
                return enemyBulletList[i];
            }
        }

        return null;
    }





    public GameObject DuvarMermiEfectCikar()
    {
        for (int i = 0; i < duvarMermiEfectList.Count; i++)
        {
            if (!duvarMermiEfectList[i].gameObject.activeInHierarchy)
            {
                return duvarMermiEfectList[i];
            }
        }

        return null;
    }
}
