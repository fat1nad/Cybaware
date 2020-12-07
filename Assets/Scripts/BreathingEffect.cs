using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BreathingEffect : MonoBehaviour
{
    TextMeshProUGUI text;
    bool mode = false; //Breathing mode. 0 is fade. 1 is lighten up
    [SerializeField, Range(0.01f, 0.05f)]
    float breathingSpeed; 

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        Color defTextColor = text.color;
    }

    void FixedUpdate()
    {
        
        if (!mode)
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - breathingSpeed);
        else
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + breathingSpeed);

        if (text.color.a <= 0)
            mode = true;
        if (text.color.a >= 1)
            mode = false;
    }
}
