using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor.SearchService;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.U2D;



public class Chave : MonoBehaviour
{
    //enemys
    public Collider2D[] enemy;
    private int contador;
    public Text ContadorEnemy;
    


    //chave 
    public GameObject door;
    private Collider2D boxKey;
    private SpriteRenderer spriteKey;
    private Collider2D doorBox;
    private Animator doorAnime;
    private Light2DBase Luz;
    




    // Start is called before the first frame update
    void Start()
    {
        boxKey = GetComponent<BoxCollider2D>();
        spriteKey = GetComponent<SpriteRenderer>();
        doorBox = door.GetComponent<Collider2D>();
        doorAnime = door.GetComponent <Animator>();
        
        Luz = GetComponent<Light2DBase>();

        

        Luz.enabled = false;
        doorAnime.enabled = false;  
        doorBox.enabled = false;
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
            Luz.enabled = true;
        }

        contador = enemy.Length;
        Check();
        ContadorEnemy.text = contador.ToString();

    }


    bool TodosEstaoDesativados(Collider2D[] enemy)
    {
        return enemy.All(enemy => !enemy.enabled);
    }

    public void Check()
    {


        foreach (Collider2D enemy in enemy)
        {
            if (!enemy.enabled)
            {
                contador--;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorBox.enabled = true;
            doorAnime.enabled = true;
            Destroy(gameObject);
        }
    }
}