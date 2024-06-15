using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFade : MonoBehaviour
{
    FadeInOut fade;

    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();

        fade.FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
