using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Ispis : MonoBehaviour
{
    public InputManager inputManager;

    Text txtLbl;
    
    void Start()
    {
        txtLbl = GetComponent<Text>();
    }

    void Update()
    {
        string debugInfo = "DEBUG INFO";
        // GPS
        debugInfo += "\n\nLocation: \nstatus \t\t" + Input.location.status;
        debugInfo += "\nlongitude \t" + Input.location.lastData.longitude;
        debugInfo += "\nlatitude \t\t" + Input.location.lastData.latitude;
        debugInfo += "\naltitude \t\t" + Input.location.lastData.altitude;
        // Žiroskop
        debugInfo += "\n\nGyroscope: \nenabled \t" + Input.gyro.enabled;
        debugInfo += "\nattitude \t" + Input.gyro.attitude;
        debugInfo += "\ngravity \t\t" + Input.gyro.gravity;
        // Kompas
        debugInfo += "\n\nCompass: \nenabled \t" + Input.compass.enabled;
        debugInfo += "\nmagnetic \t" + Input.compass.magneticHeading;
        debugInfo += "\ntrue \t\t" + Input.compass.trueHeading;
        // InputManager
        debugInfo += "\n\nTrenutna pozicija: \t" + inputManager.Location.x + ", " + inputManager.Location.y;
        debugInfo += "\nŽirova rotacija: \t\t" + inputManager.GyroAttitude;

        txtLbl.text = debugInfo;
    }
}
