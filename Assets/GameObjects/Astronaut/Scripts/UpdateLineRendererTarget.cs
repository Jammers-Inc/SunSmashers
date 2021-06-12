using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[ExecuteInEditMode]
public class UpdateLineRendererTarget : MonoBehaviour
{
    public Transform target;

    void LateUpdate()
    {
        GetComponent<LineRenderer>().SetPosition(1, target.position);
    }
}
