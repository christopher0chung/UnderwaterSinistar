using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCam : MonoBehaviour {

    public Transform target;
    public MovementReticle myMR;

    public float leadDist;

    private float dampedLeadDist;
    Vector3 offset;

	void Start () {
        offset = transform.position - target.position;
	}

    void FixedUpdate()
    {
        dampedLeadDist = Mathf.Lerp(dampedLeadDist, leadDist, .03f);
    }

    void LateUpdate () {
        ReticleInfo myRI = myMR.GetReticleInfo();

        transform.position = target.position + offset + myRI.reticleForward * myRI.reticleMag * dampedLeadDist;
	}
}
