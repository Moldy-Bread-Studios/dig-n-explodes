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
    private CircleCollider2D box;

    //animação
    public Animator movimento;

   

    void Start()
    {
        targetOfficial = targetA;
        movimento = GetComponent<Animator>();
        box = GetComponent<CircleCollider2D>();
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
            movimento.SetBool("eixo", true);
        }
        else
        {
            sr.flipX = true;
            movimento.SetBool("eixo", false);
        }

        // Definir a animação de movimento
       
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    // Reagir à colisão mudando o destino
    //    if (collision.gameObject.CompareTag("Obstacle"))
    //    {
    //        if (targetOfficial == targetA)
    //        {
               
    //            targetOfficial = targetB;
    //            movimento.SetBool("eixo", false);
                
    //        }
    //        else
    //        {
    //            targetOfficial = targetA;
    //            movimento.SetBool("eixo", true);
    //        }
    //    }
    //    if (collision.gameObject.CompareTag("bomba"))
    //    {
    //        if (targetOfficial == targetA)
    //        {
    //            targetOfficial = targetB;
    //        }
    //        else
    //        {
    //            targetOfficial = targetA;
    //        }
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("kabum"))
        {
            StartCoroutine(Morte());
        }
    }

    private IEnumerator Morte()
    {
        velocidade = 0;
        movimento.SetBool("morte", true);

        yield return new WaitForSeconds(1);

        sr.enabled = false;
        box.enabled = false;
    }

}