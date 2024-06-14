using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class Cobrinha : MonoBehaviour
{
    //movimento
    public Transform waypointA;
    public Transform waypointB;
    private Transform waypoitnActual;
    public float velocidadeAtual = 2f;
    private float velocidadeVariavel;

    //spriterender

    private SpriteRenderer sprite;

    //anima��o

    public Animator anime;

    //boxcollider

    private BoxCollider2D box;

    // terra {
    //obejto terra
    public GameObject buracoA;
    public GameObject buracoB;

    //sprite da terra
    private SpriteRenderer terraA;
    private SpriteRenderer terraB;

    //posi��o da terra
    private Transform posicaoA;
    private Transform posicaoB;
    //}

    void Start()
    {
        waypoitnActual = waypointA;
        sprite = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();

        terraA = buracoA.GetComponent<SpriteRenderer>();
        terraB = buracoB.GetComponent<SpriteRenderer>();

        posicaoA = buracoA.GetComponent<Transform>();
        posicaoB = buracoB.GetComponent<Transform>();

        sprite.enabled = false;

        box.isTrigger = true;

        velocidadeVariavel = velocidadeAtual;

        //terra

        terraA.enabled = false;
        terraB.enabled = false;

    }


    void Update()
    {

        if (waypoitnActual == waypointA && Vector2.Distance(transform.position, waypointA.position) < 0.1f)
        {
            
            sprite.enabled = true;
            terraA.enabled = true;
            StartCoroutine(Troca());
        }
        if (waypoitnActual == waypointB && Vector2.Distance(transform.position, waypointB.position) < 0.1f)
        {
            
            sprite.enabled = true;
            terraB.enabled = true;
            StartCoroutine(TrocaDnv());

        }


        transform.position = Vector2.MoveTowards(transform.position, waypoitnActual.position, velocidadeAtual * Time.deltaTime);


    }





    private IEnumerator Troca()
    {
        velocidadeAtual = 0f;
        posicaoA.position = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);

        yield return new WaitForSeconds(3);

        
        terraA.enabled = false;
        sprite.enabled = false;
        velocidadeAtual = velocidadeVariavel;
        waypoitnActual = waypointB;
        box.isTrigger = true;

    }



    private IEnumerator TrocaDnv()
    {
        velocidadeAtual = 0f;
        posicaoB.position = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);

        yield return new WaitForSeconds(3);

        
        terraB.enabled = false;
        sprite.enabled = false;
        velocidadeAtual = velocidadeVariavel;
        waypoitnActual = waypointA;
        box.isTrigger = true;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Obstacle"))
        {

            if (waypoitnActual == waypointA)
            {

                velocidadeAtual = 0f;
                box.isTrigger = false;
                sprite.enabled = true;
                terraA.enabled = true;
                StartCoroutine(Troca());

            }
            else
            {

                velocidadeAtual = 0f;
                box.isTrigger = false;
                sprite.enabled = true;
                terraB.enabled = true;
                StartCoroutine(TrocaDnv());

            }
        }
    }






}



