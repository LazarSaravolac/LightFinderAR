using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileLogging : MonoBehaviour
{
    Text txtLbl;
    string log;

    void Start()
    {
        txtLbl = GetComponent<Text>();
        log = "";
    }

    public void Log(string message)
    {
        log += "\n" + message;
        txtLbl.text = log;
    }

    public void Clear()
    {
        log = "";
    }
}
