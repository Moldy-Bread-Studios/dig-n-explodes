using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;
using Unity.VisualScripting;

public class Player : MonoBehaviour {

    public GameObject deathEffect; // Efeito de morte
    private Rigidbody2D playerRb;
    public float speed = 2f;
    float speedAtual;
    public int vida;
    public Text textHeart;
    private SpriteRenderer sprite;
    private bool noHit = false;

    //animação
    public Animator move;
    private bool andando;

    void Start() {

        playerRb = GetComponent<Rigidbody2D>();
        speedAtual = speed;  // Mova a inicialização de speedAtual para o método Start correto
        vida = 3;
        sprite = GetComponent<SpriteRenderer>();
        noHit = false;

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
        Debug.Log(textHeart.text = vida.ToString());

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
         speedAtual = 0f;
         move.SetTrigger("Morte");
         yield return new WaitForSeconds(1);
         Destroy(gameObject);
         }
     }

     
        noHit = false;




 }


    void OnCollisionEnter2D(Collision2D collision)
    {

        // Verifica se a colisão ocorreu com um objeto inimigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(!noHit)
            {
        Debug.Log("O jogador foi atingido pelo inimigo!");
                    // Executa a função para destruir o jogador
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
        
    }



  /*  void OnTriggerEnter2D(Collider2D other){
    if(other.CompareTag("porta1")){
        SceneManager.LoadScene(1);
        }

   if(other.CompareTag("porta2")){
        SceneManager.LoadScene(2);
        }

    if(other.CompareTag("porta3")){
        SceneManager.LoadScene(3);
        }
        
    if(other.CompareTag("porta4")){
        SceneManager.LoadScene(4);
        }
        
    if(other.CompareTag("final")){
        SceneManager.LoadScene(5);
        }
    }
    */

}
