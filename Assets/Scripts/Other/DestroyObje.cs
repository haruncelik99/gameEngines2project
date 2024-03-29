using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObje : MonoBehaviour
{
    private ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if(ps && !ps.IsAlive())
        {
            Destroy(gameObject);
        }
    }

    public void DestroyObjem()
    {
        Destroy(gameObject);
    }
}
