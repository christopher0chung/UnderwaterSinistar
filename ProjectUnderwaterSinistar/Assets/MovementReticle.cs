using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementReticle : MonoBehaviour {

    public float reticleSpeed;
    public float reticleBounds;

    private Vector3 _reticleLocalPos;

	void Update () {
        if (Input.GetAxis("Mouse X") != 0)
            _reticleLocalPos.x += Input.GetAxis("Mouse X") * reticleSpeed * Time.deltaTime;
        if (Input.GetAxis("Mouse Y") != 0)
            _reticleLocalPos.y += Input.GetAxis("Mouse Y") * reticleSpeed * Time.deltaTime;

        if (_reticleLocalPos.magnitude >= reticleBounds)
            _reticleLocalPos = Vector3.Normalize(_reticleLocalPos) * reticleBounds;

        transform.localPosition = _reticleLocalPos;
    }

    public ReticleInfo GetReticleInfo()
    {
       return new ReticleInfo(Mathf.Atan2(transform.localPosition.x, transform.localPosition.y) * Mathf.Rad2Deg, Vector3.Magnitude(transform.localPosition) / reticleBounds, new Vector3(transform.localPosition.x, 0, transform.localPosition.z) / reticleBounds);
    }
}

public class ReticleInfo
{
    public float reticleAng;
    public float reticleMag;
    public Vector3 reticleForward;

    public ReticleInfo (float angle, float magnitude, Vector3 dir)
    {
        reticleAng = angle;
        reticleMag = magnitude;
        reticleForward = dir;
    }
}
