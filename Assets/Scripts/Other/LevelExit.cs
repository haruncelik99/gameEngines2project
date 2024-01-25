using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LevelExit : MonoBehaviour
{
   [SerializeField] private string levelName;
   [SerializeField] private float beklemeSuresi = 2f;
   [SerializeField] private Transform centerPos;
   
   [SerializeField] private GameObject fadeImg;

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {

         PlayerHareketController.instance.hareketEdebilsinmi = false;
         other.transform.DOMove(centerPos.position, .5f);
         StartCoroutine(NextLevelRouitine());
      }
   }

   IEnumerator NextLevelRouitine()
   {
      StartCoroutine(fadeImg.GetComponent<FadeManager>().AlphaAcRouitine());
      yield return new WaitForSeconds(beklemeSuresi);
      SceneManager.LoadScene(levelName);
   }
}
