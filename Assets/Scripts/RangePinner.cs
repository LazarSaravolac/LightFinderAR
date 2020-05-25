using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangePinner : MonoBehaviour
{
    public float radiusMin = 50.0f;
    public float radiusMax = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject objectR;

    public void Range(){
        GameObject ior = Instantiate(objectR, Vector3.zero, Quaternion.identity);
        float radius = Random.Range(radiusMin, radiusMax);
        float angle = Random.Range(0, 360);
        Debug.Log(radius);
        Debug.Log(angle);
        Vector2 cartesian = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
        cartesian *= radius;
        Debug.Log(cartesian);
        Debug.Log("ior x " + ior.transform.position.x);
        Debug.Log("ior y " + ior.transform.position.y);
        Debug.Log("ior z " + ior.transform.position.z);
        Debug.Log("kamera x " + (transform.position.x + cartesian.x));
        Debug.Log("kamera y " + transform.position.y);
        Debug.Log("kamera z " + transform.position.z);
        ior.transform.position = new Vector3(transform.position.x + cartesian.x, transform.position.y, transform.position.z + cartesian.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
