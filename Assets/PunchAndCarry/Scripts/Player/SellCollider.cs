using System;
using UnityEngine;

public class SellCollider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SellPoint"))
        {
            
        }
    }
}
