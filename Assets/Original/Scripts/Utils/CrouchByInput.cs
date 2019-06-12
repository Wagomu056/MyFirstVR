using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchByInput : MonoBehaviour
{
    enum StanceType
    {
        Stand,
        Crouch
    }
    StanceType stance = StanceType.Stand;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            stance = (stance == StanceType.Stand) ? StanceType.Crouch: StanceType.Stand;

            switch (stance)
            {
                case StanceType.Stand:
                    this.transform.localPosition = Vector3.zero;
                    break;
                case StanceType.Crouch:
                    this.transform.localPosition = new Vector3(0.0f, -1.0f, 0.0f);
                    break;
            }
        }
    }
}
