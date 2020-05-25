using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pozicioniranje : MonoBehaviour
{
    public Geometry geometry;
    public InputManager inputManager;

    public float GyroOvershoot = 1.2f;
    public int CompassLag = 2;
    Queue<float> compassHeadings = new Queue<float>();
    public float GyroWeight = 0.7f;

    Quaternion previousGyro;

    Transform tr;
    Quaternion pocetnaRotacija;
    Quaternion referentni;
    
    public Vector3 CurrentLocationInScene => geometry.LocationToSceneCoordinates(inputManager.Location, inputManager.Altitude);
    
    public Quaternion CurrentRotation => pocetnaRotacija * referentni * inputManager.GyroAttitude;

    void Start()
    {
        tr = transform;
        CorrectRotation();
        previousGyro = tr.rotation;
    }
    
    void Update()
    {
        tr.position = CurrentLocationInScene;
        //tr.rotation = CurrentRotation;

        if(compassHeadings.Count == 0)
        {
            for(int i = 0; i < CompassLag; i++)
            {
                compassHeadings.Enqueue(inputManager.CompassHeading);
            }
        }
        
        Quaternion gyroRotation = tr.rotation * Quaternion.Inverse(previousGyro) * Quaternion.Slerp(previousGyro, inputManager.GyroAttitude, GyroOvershoot);
        tr.rotation = Quaternion.Slerp(CompassRotation(), gyroRotation, GyroWeight);

        compassHeadings.Dequeue();
        compassHeadings.Enqueue(inputManager.CompassHeading);
        previousGyro = inputManager.GyroAttitude;
    }

    Quaternion CompassRotation()
    {
        float heading = compassHeadings.Average();
        Quaternion compassRotation = Quaternion.Euler(0, heading, 0);
        Vector3 woBeGrDir = compassRotation * Vector3.down;
        Quaternion razlRot = Quaternion.FromToRotation(inputManager.GravityDirection, woBeGrDir);
        return compassRotation * razlRot;
    }

    public void CorrectRotation()
    {
        referentni = Quaternion.Inverse(inputManager.GyroAttitude);

        pocetnaRotacija = Quaternion.Euler(0, inputManager.CompassHeading, 0);
        Vector3 woBeGrDir = pocetnaRotacija * Vector3.down;
        Quaternion razlVRot = Quaternion.FromToRotation(inputManager.GravityDirection, woBeGrDir);
        pocetnaRotacija *= razlVRot;
    }
}
