using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrottleReticle : MonoBehaviour {

    float scale;
    float displayScale;
    
	void Update () {
		if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            scale += Input.GetAxis("Mouse ScrollWheel");
        }
        scale = Mathf.Clamp01(scale);

        displayScale = Mathf.Lerp(displayScale, scale, .05f);

        transform.localScale = new Vector3(transform.localScale.x, displayScale * 500, transform.localScale.z);
	}
}
