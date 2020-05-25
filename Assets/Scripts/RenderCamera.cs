using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderCamera : MonoBehaviour
{
    public bool isUIRawImage = true;

    void Start()
    {
        WebCamTexture camTexture = null;

        #region Set camTexture to back camera if possible
        WebCamDevice[] camDevices = WebCamTexture.devices;
        if(camDevices.Length == 0)
        {
            Debug.Log("No camera device found!");
            return;
        }

        foreach(WebCamDevice camDevice in camDevices)
        {
            if(!camDevice.isFrontFacing)
            {
                camTexture = new WebCamTexture(camDevice.name);
                Debug.Log("Found back camera.");
                break;
            }
        }
        if(!camTexture)
        {
            camTexture = new WebCamTexture(camDevices[0].name);
            Debug.Log("Using front camera.");
        }
        #endregion

        if(isUIRawImage)
        {
            GetComponent<RawImage>().texture = camTexture;
        } else {
            GetComponent<Renderer>().material.mainTexture = camTexture;
        }

        camTexture.Play();
    }
}
