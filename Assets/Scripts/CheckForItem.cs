using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForItem : MonoBehaviour
{
    
    private bool hasPickaxe = false;
    private bool hasAxe = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Checkt voor Pickaxe tag
        if (other.gameObject.CompareTag("Pickaxe"))
        {
            hasPickaxe = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Stone") && hasPickaxe)
        {
            Debug.Log("implement stone behaviour");
            Destroy(other.gameObject);
        }

    }
}
