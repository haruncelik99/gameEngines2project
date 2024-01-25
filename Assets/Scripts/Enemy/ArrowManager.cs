using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    [SerializeField] private Transform rotateTransform;
    [SerializeField] private Transform arrowSpawnPoint;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float firlatmaArasi = .5f;

    private float firlatmaSayac;

    [SerializeField] private GameObject arrowPrefab;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 enemyScreenPos = mainCamera.WorldToScreenPoint(transform.position);
        
        if(enemyScreenPos.x>0 && enemyScreenPos.x<Screen.width && enemyScreenPos.y>0 && enemyScreenPos.y<Screen.height)
        {
            if (PlayerHareketController.instance.gameObject.activeInHierarchy)
            {
                Vector2 target = rotateTransform.position - PlayerHareketController.instance.transform.position;
                float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;

                Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

                rotateTransform.rotation =
                    Quaternion.Lerp(rotateTransform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

                if (Time.time > firlatmaSayac)
                {
                    firlatmaSayac = Time.time + firlatmaArasi;
                    FireArrowFNC();
                }
            }
        }
        
        
        
        
        
    }

    void FireArrowFNC()
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
    }
    
    
    
    
    
    
    
    
    
}
