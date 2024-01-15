using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float takipMesafesi = 5f;
    [SerializeField] float hareketHizi = 5f;

    

    private Vector3 hareketYonu;

    private Rigidbody2D rb;

    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {

        if (!PlayerHareketController.instance)
        {
            return;
        }

        if (MesafeOlcFNC() < takipMesafesi)
        {
            hareketYonu = PlayerHareketController.instance.transform.position - transform.position;
        }
        hareketYonu.Normalize();
        rb.velocity = hareketYonu * hareketHizi;

        if (PlayerHareketController.instance.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = Vector3.one;
        }

        if(rb.velocity != Vector2.zero)
        {
            anim.SetBool("hareketEtsinmi", true);
        }
        else
        {
            anim.SetBool("hareketEtsinmi", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, takipMesafesi);
    }

    float MesafeOlcFNC()
    {
        return Vector2.Distance(PlayerHareketController.instance.transform.position, transform.position);
    }
}
