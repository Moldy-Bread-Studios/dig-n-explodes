using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class BolaDeFogo : MonoBehaviour
{

    Bomb bomb;
    
    private void Start()
    {
        bomb = GameObject.FindGameObjectWithTag("Player").GetComponent<Bomb>();

    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            Light2DBase luz = GetComponent<Light2DBase>();
            
            sprite.enabled = false;
            luz.enabled = false;

            

        }
        if (other.CompareTag("bomba"))
        {

            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            Light2DBase luz = GetComponent<Light2DBase>();

            sprite.enabled = false;
            luz.enabled = false;

            StartCoroutine(Kabummm());

        }
    }

    IEnumerator Kabummm()
    {
        bomb.porta = true;
        StopCoroutine(bomb.PartTwo());
        Vector3 testeV = bomb.alignedPosition;
        Destroy(bomb.bomb);
        bomb.triggerA = Instantiate(bomb.ColisaoA, testeV, Quaternion.identity);
        bomb.triggerB = Instantiate(bomb.ColisaoB, testeV, Quaternion.identity);
        bomb.Ex = Instantiate(bomb.Explosion, testeV,Quaternion.identity);

        yield return new WaitForSeconds(0.5f);

        Destroy(bomb.triggerA);
        Destroy(bomb.triggerB);
        Destroy(bomb.Ex);

    }

   
}
