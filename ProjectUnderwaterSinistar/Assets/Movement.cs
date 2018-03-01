using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Vector3 currentRot;

    public MovementReticle myMR;

    public float maxVelocity;

    float appliedDampedTurnRate;

    public float desiredVelocity;
    float setVelocity;

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
            desiredVelocity += Input.GetAxis("Mouse ScrollWheel") * maxVelocity;
        }

        desiredVelocity = Mathf.Clamp(desiredVelocity, 0, maxVelocity);
    }
	
    void FixedUpdate()
    {
        ReticleInfo myRI = myMR.GetReticleInfo();

        setVelocity = Mathf.Lerp(setVelocity, desiredVelocity, .01f);

        appliedDampedTurnRate = (1 - (1 - myRI.reticleMag) * (1 - myRI.reticleMag)) * .2f;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, myRI.reticleAng, 0), appliedDampedTurnRate);
        transform.position += transform.forward * setVelocity;
    }
}
