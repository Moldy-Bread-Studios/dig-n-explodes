using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public GameObject deathEffect; // Efeito de morte
    private bool isAlive = true; // Verifica se o jogador está vivo
    private Rigidbody2D playerRb;
    [SerializeField] float speed = 2f;
    float speedAtual;

    void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        speedAtual = speed;  // Mova a inicialização de speedAtual para o método Start correto
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

    void FixedUpdate() {  // Use FixedUpdate para manipular a física
        float eixoX = Input.GetAxisRaw("Horizontal") * speedAtual;
        float eixoY = Input.GetAxisRaw("Vertical") * speedAtual;
        playerRb.velocity = new Vector2(eixoX, eixoY);
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


}

