using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWorking : MonoBehaviour
{
    public GameObject target;
    Vector3 offset;

    bool b;

    private void LateUpdate()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            return;
        }
        else
        {
            if (!b)
            {
                offset = transform.position - target.transform.position;
                b = true;
            }

            transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * 5);
            return;
        }
    }
}
