using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMap : MonoBehaviour
{
    public string Scene;

    FadeInOut fade;

    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }
     
    public IEnumerator ChanceScene()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(Scene);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(ChanceScene());
        }
    }

  /*  private void CarregarNovaFase()
    {
        SceneManager.LoadScene(Scene);
    }
  */
}
