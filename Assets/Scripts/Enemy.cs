using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Transform targetA;
    public Transform targetB;

    private Transform targetOfficial;
    public float velocidade = 1.3f;
    public SpriteRenderer sr;

    //animação
    private Animator movimento;

   

    void Start()
    {
        targetOfficial = targetA;
        movimento = GetComponent<Animator>();
    }

    void Update()
    {
        if (targetOfficial == targetA && Vector2.Distance(transform.position, targetA.position) < 0.1f) 
        {
            targetOfficial = targetB;
        }
        if (targetOfficial == targetB && Vector2.Distance(transform.position, targetB.position) < 0.1f)
        {
            targetOfficial = targetA;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetOfficial.position, velocidade * Time.deltaTime);

        // Ajustar a orientação do sprite
        if (transform.position.x > targetOfficial.position.x)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }

        // Definir a animação de movimento
        movimento.SetBool("isWalking", true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reagir à colisão mudando o destino
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (targetOfficial == targetA)
            {
                targetOfficial = targetB;
            }
            else
            {
                targetOfficial = targetA;
            }
        }
    }
    
}