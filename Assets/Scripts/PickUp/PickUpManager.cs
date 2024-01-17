using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    private int KazanSayac = 2;

    [SerializeField] private GameObject flyTxtPrefab;
    
    public enum PickUpItems
    {
        
        Zirh,
        Can,
        Kazan
    }

    public PickUpItems pickUpItem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (pickUpItem == PickUpItems.Zirh)
            {
                PlayerHealthController.instance.ZirhiArtirFNC((1));
            }else if (pickUpItem == PickUpItems.Can)
            {
                PlayerHealthController.instance.CaniArtirFNC(1);
            }
            
            Destroy(gameObject);
        }


        if (other.CompareTag("PlayerBullet"))
        {
            if (pickUpItem == PickUpItems.Kazan)
            {
                Instantiate(flyTxtPrefab, transform.position, Quaternion.identity);
                
                KazanSayac--;
                if (KazanSayac == 1)
                {
                    GetComponent<Animator>().SetTrigger("KazanSondu");
                }
                else if (KazanSayac == 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
