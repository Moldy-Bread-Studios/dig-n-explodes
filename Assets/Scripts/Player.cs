using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class Player : MonoBehaviour {

    
    private Rigidbody2D playerRb;
    public float speed = 2f;
    float speedAtual;
    public int vida;
    public int contEnemy;
    public Text textHeart;
    private SpriteRenderer sprite;
    private bool noHit = false;
    private Collider2D box;
    


  

    //animação
    public Animator move;
    private bool andando;

    //dead
    public GameObject GameOver;
    private string cenaAtual;

    void Start() {

        playerRb = GetComponent<Rigidbody2D>();
        speedAtual = speed;  // Mova a inicialização de speedAtual para o método Start correto
        vida = 3;
        sprite = GetComponent<SpriteRenderer>();
        noHit = false;
        box = GetComponent<Collider2D>();
       

       //GameOver

        
        cenaAtual = SceneManager.GetActiveScene().name;
        GameOver.SetActive(false);

         



    }
    

    void Update() {  // Use FixedUpdate para manipular a física

        float eixoX = Input.GetAxisRaw("Horizontal") * speedAtual;
        float eixoY = Input.GetAxisRaw("Vertical") * speedAtual;
        playerRb.velocity = new Vector2(eixoX, eixoY);

        andando = eixoX != 0 || eixoY != 0;

        if (andando)
        {
            move.SetBool("isWalking", true);
            move.SetFloat("eixoX", eixoX);
            move.SetFloat("eixoY", eixoY);
        }
        else
        {
            move.SetBool("isWalking", false);
        }

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            move.SetTrigger("put");
        }

        textHeart.text = vida.ToString();
        
      
        
        



    }
    private IEnumerator DestroyPlayer()
 {
       
        noHit = true;
     vida--;
     Debug.Log(vida);

     for(int i = 0; i < 10; i++)
     {
         sprite.enabled = false;
         yield return new WaitForSeconds(0.1f);
         sprite.enabled = true;
         yield return new WaitForSeconds(0.1f);

         if(vida <= 0)
         {
                i = 9;
         speedAtual = 0f;
         move.SetTrigger("Morte");
         box.isTrigger = true;
         yield return new WaitForSeconds(1);
         GameOver.SetActive(true);
         sprite.enabled = false;
         }
     }   
        noHit = false;
        
    }

    public void Respawn()
    {
        SceneManager.LoadScene(cenaAtual);
    }




    void OnCollisionEnter2D(Collision2D collision)
    {

       
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(!noHit)
            {
        Debug.Log("O jogador foi atingido pelo inimigo!");

                    StartCoroutine(DestroyPlayer());
            }
            

        }


    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("kabum")){
            if(!noHit)
            {
                StartCoroutine(DestroyPlayer());
            }
            
        }
        if (other.CompareTag("bola"))
        {
            if (!noHit)
            {
                StartCoroutine(DestroyPlayer());
            }
        }
        

    }



  

}
