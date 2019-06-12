using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByInput : MonoBehaviour
{
    void Update()
    {
        var deltaTime = Time.deltaTime;
        UpdateTransformByInput(deltaTime);
    }

    const float Speed = 1.0f;
    void UpdateTransformByInput(float deltaTime)
    {
        var addSpeed = new Vector3(0.0f, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.J))
        {
            addSpeed.x += Speed * deltaTime;
        }
        if (Input.GetKey(KeyCode.L))
        {
            addSpeed.x -= Speed * deltaTime;
        }
        if (Input.GetKey(KeyCode.I))
        {
            addSpeed.z += Speed * deltaTime;
        }
        if (Input.GetKey(KeyCode.K))
        {
            addSpeed.z -= Speed * deltaTime;
        }

        transform.position = new Vector3(
            transform.position.x + addSpeed.x,
            transform.position.y + addSpeed.y,
            transform.position.z + addSpeed.z
        );
    }
}
