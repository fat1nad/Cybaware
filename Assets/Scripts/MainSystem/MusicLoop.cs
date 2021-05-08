using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicLoop : MonoBehaviour
{
    [SerializeField]
    AudioClip Intro;

    [SerializeField]
    AudioClip Loop;

    AudioSource audioSource;
    
    [SerializeField]
    Slider musicVolume;

    [SerializeField]
    TextMeshProUGUI musicText;

    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = Intro;
        audioSource.loop = false;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = Loop;
            audioSource.loop = true;
            audioSource.Play();
        }

        if (audioSource.volume != (musicVolume.value / musicVolume.maxValue))
        {
            musicText.text = musicVolume.value.ToString();
            audioSource.volume = (musicVolume.value/musicVolume.maxValue);
        }
    }

}
