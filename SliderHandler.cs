using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderHandler : MonoBehaviour

{

    public Slider mySlider;
    // Start is called before the first frame update

    void Start()
    {
        print("Hello!");

        mySlider.onValueChanged.AddListener (
            (v) => { 
                int v2 = (int) (v * 100.0);
                print("Value:" + v2);}
        );    
    }

    //m_card.GetComponent<Button>().onClick.AddListener(() => {InitializeCardScreen(cardItem);});

    // Update is called once per frame
    void Update()
    {
        
    }
}
