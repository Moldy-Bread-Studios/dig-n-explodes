using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class Player : MonoBehaviour {

    public GameObject deathEffect; // Efeito de morte
    private bool isAlive = true; // Verifica se o jogador está vivo
    private Rigidbody2D playerRb;
    public float speed = 2f; //que porra é essa ????????
    float speedAtual;

    //animação
    public Animator move;
    private bool andando;

    void Start() {

        playerRb = GetComponent<Rigidbody2D>();
        speedAtual = speed;  // Mova a inicialização de speedAtual para o método Start correto

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

    }
    void DestroyPlayer()
    {
        // Verifica se o jogador já não foi destruído
        if (isAlive)
        {
            isAlive = false; // Define o jogador como morto
            // Adicione aqui qualquer lógica adicional, como efeitos de morte, contagem de vidas, etc.
            Destroy(gameObject); // Destroi o objeto do jogador
            Instantiate(deathEffect, transform.position, Quaternion.identity); // Instancia o efeito de morte
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        // Verifica se a colisão ocorreu com um objeto inimigo
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Debug.Log("O jogador foi atingido pelo inimigo!");
            // Executa a função para destruir o jogador
            DestroyPlayer();

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

