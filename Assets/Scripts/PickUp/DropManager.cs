using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    [SerializeField] private bool nesneBirakabilirmi;
    [SerializeField] private PickUpManager[] pickItems;

    public void NesneyiBirakFNC()
    {
        if (nesneBirakabilirmi)
        {
            int randomItem = Random.Range(0, pickItems.Length);
            PickUpManager pickItem = Instantiate(pickItems[randomItem], transform.position, Quaternion.identity);
        }
    }


}
