using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    Chefe boss;
    private Collider2D box;

    private void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Chefe>();
        box = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (boss.death)
        {
            box.enabled = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
            if (!boss.timer)
            {
                if(!boss.noHit)
            {
                StartCoroutine(boss.Attack());
            }
            }
            
            
            }
        }
}
