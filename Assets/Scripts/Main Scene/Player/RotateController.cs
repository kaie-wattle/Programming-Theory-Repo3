using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    private float rotateSpeed = 2f;
    private float returnRotateSpeed = 2f;
    private float rotateLimit = 45f;

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerRotate();
    }

    void PlayerRotate()
    {
        var parent = GetComponentInParent<PlayerController>();
        float currentAngles = transform.localEulerAngles.z;
        if (transform.localEulerAngles.z > 180)
        {
            currentAngles -= 360;
        }
        if (parent.zRotate > 0)
        {
            if (currentAngles < rotateLimit)
            {
                transform.Rotate(new Vector3(0, 0, parent.zRotate) * rotateSpeed);
            }
            
        }
        else if(parent.zRotate < 0)
        {
            if (currentAngles > -rotateLimit)
            {
                transform.Rotate(new Vector3(0, 0, parent.zRotate) * rotateSpeed);
            }
        }
        else
        {
            if (currentAngles <= 2f && currentAngles >= -2f)
            {
                transform.rotation = default;
            }
            else if (currentAngles > 0f)
            {
                transform.Rotate(new Vector3(0, 0, -returnRotateSpeed));
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, returnRotateSpeed));
            }
            
        }
    }
}
