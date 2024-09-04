using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoDoBoss : MonoBehaviour
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
        if (other.CompareTag("kabum"))
        {
            StartCoroutine(boss.Hit());
            Debug.Log("ta acessando" + boss.vidas);
        }
    }
}
