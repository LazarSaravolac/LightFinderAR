using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Fejkovanje
    public bool fejk = true;
    public Vector2 lokacija = new Vector2(19.82073f, 45.28317f);
    public float visina;
    public Transform Ziroskop;
    public Transform Gravitacija;
    public float kompas;
    public bool lokacijaUkljucena;
    #endregion

    #region Sensors' properties
    public Quaternion GyroAttitude => fejk ? Ziroskop.rotation : Geometry.GyroToUnity(Input.gyro.attitude);
    public Vector3 GravityDirection => fejk ? -Gravitacija.up : Geometry.GyroGravityToUnity(Input.gyro.gravity);
    public bool LocationOn => fejk ? lokacijaUkljucena : Input.location.status == LocationServiceStatus.Running;
    public float CompassHeading => fejk ? kompas : (LocationOn ? Input.compass.trueHeading : Input.compass.magneticHeading);
    public Vector2 Location => (fejk || !LocationOn) ? lokacija : new Vector2(Input.location.lastData.longitude, Input.location.lastData.latitude);
    public float Altitude => (fejk || !LocationOn) ? visina : Input.location.lastData.altitude;
    #endregion

    void Start()
    {
        if(!fejk)
        {
            Input.gyro.enabled = true;
            Input.compass.enabled = true;
            Input.location.Start();
        }
    }
}
