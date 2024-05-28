using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject bomba;  // Referência ao prefab da bomba
    public KeyCode placeBombKey = KeyCode.Space;  // Tecla para colocar a bomba
    public float gridSize = 1f;  // Ajuste este valor para o tamanho da sua grade
    public float timeBomb = 3f; //tempo para explodir
    public int quantidadeBomb = 1; //quantidade de bombas
    private int bombRestantes; //bomba restantes no inventario
    public LayerMask solidObjectsLayer; // Camada dos objetos sólidos

    //colisoes

    public GameObject ColisaoA;
    public GameObject ColisaoB;



    private void OnEnable()
    {
        bombRestantes = quantidadeBomb;
    }


    void Update()
    {
        if (bombRestantes > 0 && Input.GetKeyDown(placeBombKey)) // se o seu invetario tiver mais bombas e apertar o espaço ele ativa
        {
            StartCoroutine(PlaceBomb());
        }
    }


    private IEnumerator PlaceBomb()
    {
        // Obtém a posição do jogador
        Vector3 playerPosition = transform.position;

        // Calcula a posição alinhada à grade
        Vector3 alignedPosition = new Vector3(
            Mathf.Round(playerPosition.x / gridSize) * gridSize,
            Mathf.Round(playerPosition.y / gridSize) * gridSize,
            playerPosition.z  // Mantém a posição Z original
        );

        GameObject bomb = Instantiate(bomba, alignedPosition, Quaternion.identity);
        bombRestantes--;

        yield return new WaitForSeconds(timeBomb);
       
        Destroy(bomb);
        bombRestantes++;

        GameObject A = Instantiate(ColisaoA, alignedPosition, Quaternion.identity);
        GameObject B = Instantiate(ColisaoB, alignedPosition, Quaternion.identity);

        yield return new WaitForSeconds(1);

        Destroy(A);
        Destroy(B);
    }
}
