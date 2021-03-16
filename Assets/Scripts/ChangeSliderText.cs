using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class ChangeSliderText : MonoBehaviour
{
    public TMP_Text sliderValue;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue.text = ((int)(slider.value*100)).ToString();
    }
}
