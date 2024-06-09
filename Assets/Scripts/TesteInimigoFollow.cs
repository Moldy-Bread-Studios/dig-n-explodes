using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class TesteInimigoFollow : MonoBehaviour
{

    //perseguição
    
    public float distancia = 100f;
    private float distance;
    public Transform pointA;
    private float velocidade = 2f;
    private float velocidadeVariavel;

    //waypoints

    public Transform waypointA;
    public Transform waypointB;
    private Transform waypointAtual;
    public SpriteRenderer sr; 


    //Start
    void Start()
    {

        
        waypointAtual = waypointA;
        velocidadeVariavel = velocidade;

    }

    //Update 
    void Update()
    {

        //pegando a distancia entre o player e o inimigo
        Vector2 positionA = transform.position;
        Vector2 positionB = pointA.transform.position;

        distance = Vector2.Distance(positionA, positionB);

        Debug.Log(distance);

        //se o inimigo chegar no wayA, ele ira pro wayB. e vise versa
        if(waypointAtual == waypointA && Vector2.Distance(transform.position, waypointA.position) < 0.1f)
        {
            waypointAtual = waypointB;
        }
        if(waypointAtual == waypointB && Vector2.Distance(transform.position, waypointB.position) < 0.1f)
        {
            waypointAtual = waypointA;
        }
        

        

        //se o player estiver perto, ele ira perseguilo, se nao, era do wayA por wayB

        if (distance <= distancia)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, velocidade * Time.deltaTime);
            
            if (transform.position.x > pointA.position.x)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }

            StartCoroutine(Pancada());
        }
        else if(distance >= distancia)
        {
            velocidade = velocidadeVariavel;
            transform.position = Vector3.MoveTowards(transform.position, waypointAtual.position, velocidade * Time.deltaTime);

            if (transform.position.x > waypointAtual.position.x)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }
        }


        
    }

    private IEnumerator Pancada()
    {

        velocidade = 5f;

        yield return new WaitForSeconds(1);

        velocidade = 0f;

        

    }




}
