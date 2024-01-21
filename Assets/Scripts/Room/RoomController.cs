using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
   [SerializeField] private List<GameObject> dusmanlar;
   [SerializeField] private List<GameObject> kapilar;

   private void Update()
   {
      if (dusmanlar.Count > 0)
      {
         for (int i = 0; i < dusmanlar.Count; i++)
         {
            if (!dusmanlar[i].gameObject.activeInHierarchy)
            {
               dusmanlar.RemoveAt(i);
               i--;
            }
         }
      }
      else
      {
         foreach (GameObject kapi in kapilar)
         {
            kapi.gameObject.SetActive(false);
         }
         {
            
         }
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         CameraController.instance.HedefTransform(transform);

         if (dusmanlar.Count == 0)
         {
            foreach (GameObject kapi in kapilar)
            {
               kapi.gameObject.SetActive(false);
            }
         }
         else
         {
            foreach (GameObject kapi in kapilar)
            {
               kapi.gameObject.SetActive(true);
            }
         }
         
      }
   }
}
