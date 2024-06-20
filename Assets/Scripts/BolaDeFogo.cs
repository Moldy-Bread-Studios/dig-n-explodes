using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BolaDeFogo : MonoBehaviour
{

    
    
    private void Start()
    {
        
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            
            sprite.enabled = false;

            

        }
        if (other.gameObject.CompareTag("bomba"))
        {
            
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            
            sprite.enabled = false;
            
            



        }
    }

   
}
