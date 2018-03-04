using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotationSpeed : MonoBehaviour {

    public AxisOfRotation myAxis;
    public float degreePerSecond;

    private float rotAng;
    private Vector3 rotEuler;
	
	void Update () {
        rotAng += degreePerSecond + Time.deltaTime;
        if (rotAng > 360 || rotAng < 0)
            rotAng = (rotAng + 360) % 360;

        if (myAxis == AxisOfRotation.x)
        {
            rotEuler.x = rotAng;
            rotEuler.y = rotEuler.z = 0;
        }
        if (myAxis == AxisOfRotation.y)
        {
            rotEuler.y = rotAng;
            rotEuler.x = rotEuler.z = 0;
        }
        else
        {
            rotEuler.z = rotAng;
            rotEuler.y = rotEuler.x = 0;
        }
        transform.localRotation = Quaternion.Euler(rotEuler);
	}

    public enum AxisOfRotation { x, y, z}
}
