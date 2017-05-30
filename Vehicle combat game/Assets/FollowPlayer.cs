using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {


    public GameObject target;
    public float rotateSpeed = 5;
    Vector3 offset;

    public float MinimumX = -90F;
    public float MaximumX = 90F;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        target.transform.Rotate(-vertical, horizontal, 0);

        float desiredAngleHorizontal = target.transform.eulerAngles.y;
        float desiredAngleVertical = target.transform.eulerAngles.x;

        Quaternion rotationHorizontal = Quaternion.Euler(desiredAngleVertical, desiredAngleHorizontal, 0);
        transform.position = target.transform.position - (rotationHorizontal * offset);



        transform.LookAt(target.transform);

        Cursor.lockState = CursorLockMode.Locked;
    }
    
}
