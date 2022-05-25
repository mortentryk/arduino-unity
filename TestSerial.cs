using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class TestSerial : MonoBehaviour {
    SerialPort sp;
    float next_time; int ii = 0;
    // Use this for initialization
    void Start () {
        print ("hello");
        string the_com="";
        next_time = Time.time;
        
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
                    if (sp.IsOpen) { print("Open"); }
                }
                break;
            }
        }
    }

    // Update is called once per frame
        // Update is called once per frame
    void Update() {
        if (Time.time > next_time) { 
            if (!sp.IsOpen)
            {
                sp.Open();
                print("opened sp");
            }
            if (sp.IsOpen)
            {
                print("Writing " + ii);
                sp.Write((ii.ToString()));
            }
            next_time = Time.time + 5;
            if (++ii > 9) ii = 0;
        }
    }     

}
