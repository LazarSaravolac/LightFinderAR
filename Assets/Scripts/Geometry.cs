using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Geographic coordinates
/*
blizu
45.252343
19.838458
*/
/*
daleko
45.28317
19.82073
*/
/*
Istok vidovdansko naselje
45.283192
19.833142
*/
#endregion

public class Geometry : MonoBehaviour
{
    public Vector2 koordPocetak = new Vector2(19.84259f, 45.25438f);
    public int skala = 100000;

    public Vector3 LocationToSceneCoordinates(Vector2 location, float altitude)
    {
        location -= koordPocetak;
        location *= skala;
        Vector3 location3d = new Vector3(location.x, altitude, location.y);
        return location3d;
    }

    public static Quaternion GyroToUnity(Quaternion q) => new Quaternion(q.x, q.y, -q.z, -q.w);

    public static Vector3 GyroGravityToUnity(Vector3 g) => new Vector3(g.x, g.y, -g.z);

    #region Debugging stuff

    int compassSign = 1;
    bool includeGravity = true;
    bool gravitySign = false;
    bool fromTo = true;

    public void ChangeCompassSign() 
    {
        compassSign = -compassSign;
    }

    public void ChangeGravityIncluded()
    {
        includeGravity = !includeGravity;
    }

    public void ChangeGravitySign()
    {
        gravitySign = !gravitySign;
    }

    public void ChangeFromToDirection()
    {
        fromTo = !fromTo;
    }

    #endregion
}
