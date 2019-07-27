using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 cameraOffset;
    [Range(.01f, 1f)]
    public float smoothFactor = .5f;
    public bool lookAtPlayer = false;

    public bool rotateAroundPlayer = true;
    public float rotationSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (rotateAroundPlayer && Input.GetMouseButton(1))
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            cameraOffset = camTurnAngle * cameraOffset;
        }
        Vector3 newPos = playerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (lookAtPlayer || rotateAroundPlayer)
        {
            transform.LookAt(playerTransform);
        }
    }
}
