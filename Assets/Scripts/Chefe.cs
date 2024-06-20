using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;


public class Chefe : MonoBehaviour
{

    //movimentação
    public Transform WayA;
    public Transform WayB;
    private Transform WayAtual;
    private SpriteRenderer sprite;
    public Collider2D box;

    //animação
    public Animator anime;

    //velocidade
    public float velocidade;
    public float velocidadeAtual = 6f;

    //randomizador de numeros
    private int Randomizador;

    //bola de fogo
    public GameObject fireBall;
    Rigidbody2D rb;

    //vida
    public int vidas = 4;
    private bool noHit = false;
    
  

    void Start()
    {
        noHit = false;
        sprite = gameObject.GetComponent<SpriteRenderer>();
        WayAtual = WayA;
        velocidade = velocidadeAtual;
        rb = fireBall.GetComponent<Rigidbody2D>();

    }

    
    void Update()
    {
        

       
        
        if(transform.position == WayAtual.position && Vector2.Distance(transform.position, WayAtual.position) < 0.1f)
        {
            StartCoroutine(Buraco());
            
            

        }

        transform.position = Vector3.MoveTowards(transform.position, WayAtual.position, velocidade * Time.deltaTime);
    }

    private IEnumerator Buraco()
    {
        sprite.enabled = false;
        box.enabled = false;
        WayAtual = null;
        yield return new WaitForSeconds(1);

        Randomizador = Random.Range(1, 5);
        sprite.enabled = true;
        box.enabled = true;
        transform.localScale = new Vector2 (-1f, 1f);
                
        switch (Randomizador)
        {
            case 1:
                
                WayA.position = new Vector2(-12f, -1f);
                transform.position = new Vector2(15f, -1f);
                sprite.enabled = true;
                transform.localScale = new Vector2(1f, 1f);
                WayAtual = WayA;
                break;

            case 2:
                
                WayA.position = new Vector2(13f, -1f);
                transform.position = new Vector2(-13f, -1f);
                sprite.enabled = true;
                WayAtual = WayA;
                break;

            case 3:
                
                WayA.position = new Vector2(-12f, 3f);
                transform.position = new Vector2(15f, 3f);
                sprite.enabled = true;
                transform.localScale = new Vector2(1f, 1f);
                WayAtual = WayA;
                break;

            case 4:
                
                WayA.position = new Vector2(13f, 3f);
                transform.position = new Vector2(-13f, 3f);
                sprite.enabled = true;
                WayAtual = WayA;
                break;



        }
        
    }

    private IEnumerator Attack()
    {
            


        velocidade = 0;
        anime.SetTrigger("Attack");
        anime.SetBool("IsWalking", false);
        StartCoroutine(FireBall());

        yield return new WaitForSeconds(1.5f);

        anime.SetBool("IsWalking", true);
        velocidade = velocidadeAtual;
        
    }

    private IEnumerator FireBall()
    {
        Transform point = fireBall.GetComponent<Transform>();
       
        
        SpriteRenderer sprite = fireBall.GetComponent<SpriteRenderer>();
        
        
        yield return new WaitForSeconds(1);
        sprite.enabled = true;
        
        if (transform.localScale.x < 0f)
        {
            sprite.flipX = false;
            point.position = new Vector2(transform.position.x, transform.position.y);
            rb.AddForce(Vector2.right * 10f, ForceMode2D.Impulse);

        }
        else if (transform.localScale.x > 0f)
        {
            sprite.flipX = true;
            point.position = new Vector2(transform.position.x, transform.position.y);
            rb.AddForce(Vector2.left * 10f, ForceMode2D.Impulse);
            
            
        }

        yield return new WaitForSeconds(2.5f);

        rb.velocity = Vector2.zero;
    }

    private IEnumerator Hit()
    {
        UnityEngine.Color colorRed = UnityEngine.Color.red;
        UnityEngine.Color colorNone = UnityEngine.Color.white;
        noHit = true;
        vidas--;
        Debug.Log(vidas);

        for (int i = 0; i < 10; i++)
        {
            sprite.color = colorRed;
            yield return new WaitForSeconds(0.1f);
            sprite.color = colorNone;
            yield return new WaitForSeconds(0.1f);

            if (vidas <= 0)
            {
                velocidade = 0f;
                anime.SetTrigger("Morte");
                yield return new WaitForSeconds(1);
                Destroy(gameObject);
            }
        }
        noHit = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Attack());
        }
        if (other.gameObject.CompareTag("kabum"))
        {
            StartCoroutine(Hit());
        }
    }
}
