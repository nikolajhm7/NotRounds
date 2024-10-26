using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static float LookInDirRotation(Vector2 dirLook, Vector2 dirBase)
    {
        //Vector3.Angle only returns between 0-180, rotating fromAngle by 90 degrees and finding sign of the dot product between this
        //and dirToCursor allows us to properly rotate for angles greater than 180
        Vector2 dirBaseRotated = Quaternion.AngleAxis(90, Vector3.forward) * dirBase;
        return Mathf.Sign(Vector2.Dot(dirLook, dirBaseRotated)) * Vector3.Angle(dirBase, dirLook);
    }

}

