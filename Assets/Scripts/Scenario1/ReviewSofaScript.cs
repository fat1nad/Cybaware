using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewSofaScript : MonoBehaviour
{
    private Sofa SelectedSofa;
    // Start is called before the first frame update
    void Start()
    {
        SelectedSofa = GameObject.FindObjectOfType<Sofa>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
