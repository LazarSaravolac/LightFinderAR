using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uljez : MonoBehaviour
{
    public string ime;
    public Vector2 lokacija;
    /*
    45°15'18.3"N 19°50'42.2"E
    45.255080, 19.845066
    */

    void Start()
    {
        Geometry inputManager = FindObjectOfType<Geometry>();
        transform.position = inputManager.LocationToSceneCoordinates(lokacija, transform.position.y);

        NameSpawner nameSpawner = FindObjectOfType<NameSpawner>();
        nameSpawner.AddObject(ime, transform);
    }
}
