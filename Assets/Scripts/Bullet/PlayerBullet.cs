using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float mermiHizi = 10f;
    [SerializeField] private int mermiHasarGucu = 10;

    private Rigidbody2D rb;

    private AudioSource _audioSource;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _audioSource.volume = PlayerPrefs.GetFloat("SFXVolume");
    }

    private void Update()
    {
        if(rb != null)
        {
            rb.velocity = (Vector2)(transform.right * mermiHizi);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealthController>().HasarAlFNC(mermiHasarGucu);
            this.gameObject.SetActive(false);
        }


        if (other.CompareTag("Wall"))
        {
            GameObject duvarEfecti = null;
            duvarEfecti = ObjectPool.instance.DuvarMermiEfectCikar();

            duvarEfecti.transform.position = this.transform.position;
            duvarEfecti.transform.rotation = Quaternion.identity;

            duvarEfecti.gameObject.SetActive(true);



            this.gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

}
