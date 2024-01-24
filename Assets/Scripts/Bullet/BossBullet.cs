using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossBullet : MonoBehaviour
{
    [SerializeField] private float mermiHizi = 10f;
    [SerializeField] private int hasarMiktari = 1;

    private SpriteRenderer sr;
    [SerializeField] private Sprite[] srResimler;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        sr.sprite = srResimler[Random.Range(0, srResimler.Length)];
    }


    private void Update()
    {
        transform.Translate(Vector3.right*mermiHizi*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealthController>().HasarAlFNC(hasarMiktari);
        }

        gameObject.SetActive(false);
    }
}
