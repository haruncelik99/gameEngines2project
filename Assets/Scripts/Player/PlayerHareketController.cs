using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHareketController : MonoBehaviour
{
    public static PlayerHareketController instance;

    [Header("Hareket Ayarlari")]
    [SerializeField] private float normalHareketHizi = 10f;
    [SerializeField] private float kosmaHareketHizi = 20f;
    
    
    private float hareketHizi;
    
    private Vector2 hareketVectoru;

    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private Transform handTransform;
    
    [HideInInspector]
    public bool hareketEdebilsinmi = true;

    [HideInInspector]
    public bool geriTepkiOlsunmu = false;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        hareketHizi = normalHareketHizi;
    }

    private void Update()
    {
        if (!geriTepkiOlsunmu)
        {
            if (hareketEdebilsinmi)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    hareketHizi = kosmaHareketHizi;
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    hareketHizi = normalHareketHizi;
                }
                HareketFNC();
                SilahiDondurFNC();
            }
            else
            {
                rb.velocity = Vector2.zero;
                hareketHizi = 0;
                anim.SetBool("hareketEtsinmi",false);
            }
        }
        
        
            
        
        
        
    }

    public IEnumerator GeriTepkiFNC(float forceX, float forceY, float duration, Transform otherObject)
    {
        
        geriTepkiOlsunmu = true;
        
        int geriTepkiDirection;
        if (transform.position.x < otherObject.position.x)
        {
            geriTepkiDirection = -1;
            
        }
        else
        {
            geriTepkiDirection = 1;
        }

        rb.velocity = Vector2.zero;
        Vector2 force = new Vector2(geriTepkiDirection * forceX, forceY);
        rb.AddForce(force,ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        geriTepkiOlsunmu = false;
        rb.velocity = Vector2.zero;

    }
    
    
    

    void HareketFNC()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        hareketVectoru = new Vector2(x: h, y: v);
        hareketVectoru.Normalize();
        //float vectorUzunlugu = hareketVectoru.magnitude * hareketHizi;


        rb.velocity = hareketVectoru * hareketHizi;

        if(rb.velocity != Vector2.zero)
        {
            anim.SetBool(name:"hareketEtsinmi",value:true );
        }

        else
        {
            anim.SetBool(name: "hareketEtsinmi", value: false);
        }


    }

    void SilahiDondurFNC()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 hareketYonu = new Vector2(x: mousePos.x - playerPoint.x, mousePos.y - playerPoint.y);
        float angle = Mathf.Atan2(hareketYonu.y, hareketYonu.x) * Mathf.Rad2Deg;
        

        handTransform.rotation = Quaternion.Euler(x: 0, y: 0, z: angle);

        if (mousePos.x < playerPoint.x)
        {
            transform.localScale = new Vector3(x: -1, y: 1, z: 1);
            handTransform.localScale = new Vector3(x: -1, y: -1, z: 1);
        }
        else
        {
            transform.localScale = Vector3.one;
            handTransform.localScale = Vector3.one;

        }
    }
}
