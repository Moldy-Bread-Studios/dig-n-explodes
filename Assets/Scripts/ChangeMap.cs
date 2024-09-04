using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMap : MonoBehaviour
{
    public string Scene;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene(Scene);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(Scene);
    }

    private void CarregarNovaFase()
    {
        SceneManager.LoadScene(Scene);
    }
  
}
