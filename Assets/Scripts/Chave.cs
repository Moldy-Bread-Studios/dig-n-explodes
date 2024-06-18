using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Chave : MonoBehaviour
{
    //enemys
    public Collider2D[] enemy;


    //chave 
    public BoxCollider2D door;
    private Collider2D boxKey;
    private SpriteRenderer spriteKey;


    // Start is called before the first frame update
    void Start()
    {
        boxKey = GetComponent<BoxCollider2D>();
        spriteKey = GetComponent<SpriteRenderer>();
        door.enabled = false;
        boxKey.enabled = false;
        spriteKey.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        if(TodosEstaoDesativados(enemy))
        {
            boxKey.enabled = true;
            spriteKey.enabled = true;
        }

    }


    bool TodosEstaoDesativados(Collider2D[] enemy)
    {
        return enemy.All(enemy => !enemy.enabled);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.enabled = true;
            Destroy(gameObject);
        }
    }
}