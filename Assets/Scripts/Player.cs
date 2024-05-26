using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    private Rigidbody2D playerRb;
    [SerializeField] float speed = 2f;
    float speedAtual;

    void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        speedAtual = speed;  // Mova a inicialização de speedAtual para o método Start correto
    }

    void FixedUpdate() {  // Use FixedUpdate para manipular a física
        float eixoX = Input.GetAxisRaw("Horizontal") * speedAtual;
        float eixoY = Input.GetAxisRaw("Vertical") * speedAtual;
        playerRb.velocity = new Vector2(eixoX, eixoY);
    }
}

