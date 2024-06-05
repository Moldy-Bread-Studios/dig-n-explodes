using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeste : MonoBehaviour
{
    //movimento
    public Transform waypointA;
    public Transform waypointB;
    private Transform waypoitnActual;
    public float velocidade = 2f;

    //spriterender

    public SpriteRenderer sprite;

    //animação

    public Animator anime;

    void Start()
    {
        waypoitnActual = waypointA;
        sprite = GetComponent<SpriteRenderer>();
        anime.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoitnActual.position, velocidade * Time.deltaTime);

        
            StartCoroutine(Troca());
        
    }

    private IEnumerator Troca()
    {

        Debug.Log("entrou na coroutine");
        if(transform.position == waypointA.position) {
            Debug.Log("entrou dentro do if");
        anime.enabled = true;
        anime.SetBool("fora", true);
        
        yield return new WaitForSeconds(5);

        anime.SetBool("fora", false);
        sprite.flipX = true;

        yield return new WaitForSeconds(1);

        sprite.flipX = false;

        yield return new WaitForSeconds(2);

        anime.SetBool("dentro", true);

        yield return new WaitForSeconds(2);

            anime.enabled = false;
            waypoitnActual.position = waypointB.position;

        }

        if (transform.position == waypointB.position)
        {

            anime.enabled = true;
            anime.SetBool("fora", true);

            yield return new WaitForSeconds(5);

            anime.SetBool("fora", false);
            sprite.flipX = true;

            yield return new WaitForSeconds(1);

            sprite.flipX = false;

            yield return new WaitForSeconds(2);

            anime.SetBool("dentro", true);

            yield return new WaitForSeconds(2);

            anime.enabled = false;
            waypoitnActual.position = waypointA.position;

        }

    }
}
