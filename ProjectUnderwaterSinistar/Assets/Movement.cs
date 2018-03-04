using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Vector3 currentRot;

    public MovementReticle myMR;
    public ThrottleReticle myTR;

    public float maxVelocity;

    float appliedDampedTurnRate;

    public float desiredVelocity;
    float setVelocity;

    void FixedUpdate()
    {
        ReticleInfo myRI = myMR.GetReticleInfo();
        float throttleScale = myTR.GetThrottle();

        desiredVelocity = maxVelocity * throttleScale;

        setVelocity = Mathf.Lerp(setVelocity, desiredVelocity, .01f);

        appliedDampedTurnRate = (1 - (1 - myRI.reticleMag) * (1 - myRI.reticleMag)) * .2f;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, myRI.reticleAng, 0), appliedDampedTurnRate);
        transform.position += transform.forward * setVelocity;
    }
}
