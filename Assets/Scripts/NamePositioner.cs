using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePositioner : MonoBehaviour
{
    static float fullyVisibleRange = 0.25f;
    Transform nameTr;
    Transform objectTr;
    Camera cam;
    Text text;
    public string objectName;
    public Vector3 worldPosition;
    public Vector3 screenPosition;
    public Vector3 viewportPosition;

    void Start()
    {
        nameTr = transform;
        cam = Camera.main;
        text = GetComponent<Text>();
    }

    void Update()
    {
        worldPosition = objectTr.position;
        screenPosition = cam.WorldToScreenPoint(objectTr.position);
        viewportPosition = cam.ScreenToViewportPoint(nameTr.position);

        nameTr.position = new Vector3(screenPosition.x, screenPosition.y, 0);
        
        Color oldC = text.color;
        float alpha;
        if(Outside(viewportPosition) || screenPosition.z < 0)
        {
            alpha = 0;
        } else {
            float dist = DistFromCenterSq(viewportPosition.x, viewportPosition.y);
            if(dist > fullyVisibleRange)
            {
                alpha = Mathf.InverseLerp(0.9f, fullyVisibleRange, dist);
            } else {
                alpha = 1;
            }
        }
        text.color = new Color(oldC.r, oldC.g, oldC.g, alpha);
    }

    static bool Outside(Vector3 v) => v.x < 0 || v.x > 1 || v.y < 0 || v.y > 1;

    static float DistFromCenterSq(float x, float y) 
    {
        x -= 0.5f;
        x *= 2;
        y -= 0.5f;
        y *= 2;
        return x * x + y * y;
    }

    public void SetName(string name)
    {
        if(!text) text = GetComponent<Text>();
        text.text = objectName = name;
    }

    public void SetLabeledObject(Transform LOTr)
    {
        objectTr = LOTr;
    }
}
