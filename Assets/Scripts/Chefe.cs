using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Chefe : MonoBehaviour
{
    public Transform WayA;
    public Transform WayB;
    private Transform WayAtual;
    private SpriteRenderer sprite;
    public float velocidade = 2;
    private int Randomizador;
    void Start()
    {
    
        sprite = gameObject.GetComponent<SpriteRenderer>();
        WayAtual = WayA;
        
        
    }

    
    void Update()
    {
        
        
        if(transform.position == WayAtual.position && Vector2.Distance(transform.position, WayAtual.position) < 0.1f)
        {
            StartCoroutine(Buraco());
            Randomizador = Random.Range(1, 4);
            sprite.enabled = false;

        }

        transform.position = Vector3.MoveTowards(transform.position, WayAtual.position, velocidade * Time.deltaTime);
    }

    private IEnumerator Buraco()
    {
       
        yield return new WaitForSeconds(1);
        WayAtual = null;
        
        Debug.Log(Randomizador);
        
        sprite.flipX = false;
        switch (Randomizador)
        {
            case 1:
                WayA.position = new Vector2(-10f, -1.5f);
                transform.position = new Vector2(13f, -1.5f);
                sprite.enabled = true;
                sprite.flipX = true;
                WayAtual = WayA;
                break;

            case 2:
                WayA.position = new Vector2(12f, -1.5f);
                transform.position = new Vector2(-11f, -1.5f);
                sprite.enabled = true;
                WayAtual = WayA;
                break;

            case 3:
                WayA.position = new Vector2(-10f, 2.5f);
                transform.position = new Vector2(13f, 2.5f);
                sprite.enabled = true;
                sprite.flipX = true;
                WayAtual = WayA;
                break;

            case 4:
                WayA.position = new Vector2(12f, 2.5f);
                transform.position = new Vector2(-11f, 2.5f);
                sprite.enabled = true;
                WayAtual = WayA;
                break;


        }
        
    }
}
