using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

//using UnityEngine.UIElements;

//[RequireComponent(typeof(UIDocument))]
public class ArduinoSLider : MonoBehaviour {
    public Slider mySlider;
    SerialPort sp;
    //float next_time; int ii = 0;

    // Use this for initialization
    void Start () {
        print ("hello");
        
        string the_com="";
        //next_time = Time.time;
        
        foreach (string mysps in SerialPort.GetPortNames())
        {
            print(mysps);
            if (mysps.Contains("usb")) {
                the_com = mysps;
                sp = new SerialPort(the_com, 9600);
                if (!sp.IsOpen)
                {
                    print("Opening " + the_com + ", baud 9600");
                    sp.Open();
                    sp.ReadTimeout = 100;
                    sp.Handshake = Handshake.None;
                    if (sp.IsOpen) {
                        print("Open");
                    }
                }
                break;
            }
        }
        mySlider.onValueChanged.AddListener (
            (v) => {
                if (sp == null) {
                    return;
                } 
                else if (!sp.IsOpen)
                {
                    print("Board is not connected");
                }
                else 
                {
                    int v2 = (int) (v * 255.0);
                    sp.Write((v2.ToString() + "\n"));
                    print("Sent to Arduino:" + v2);
                }

            }
        );
    }

    // Update is called once per frame
        // Update is called once per frame
    void Update() {
    }


    ////////
    /*
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.Add(new Label("Press any key to see the keyDown properties"));
        root.Add(new TextField());
        root.Q<TextField>().Focus();
        root.RegisterCallback<KeyDownEvent>(OnKeyDown, TrickleDown.TrickleDown);
        root.RegisterCallback<KeyUpEvent>(OnKeyUp, TrickleDown.TrickleDown);
    }
    void OnKeyDown(KeyDownEvent ev)
    {
        Debug.Log("KeyDown:" + ev.keyCode);
        Debug.Log("KeyDown:" + ev.character);
        Debug.Log("KeyDown:" + ev.modifiers);
    }

    void OnKeyUp(KeyUpEvent ev)
    {
        Debug.Log("KeyUp:" + ev.keyCode);
        Debug.Log("KeyUp:" + ev.character);
        Debug.Log("KeyUp:" + ev.modifiers);
    }
    */
}