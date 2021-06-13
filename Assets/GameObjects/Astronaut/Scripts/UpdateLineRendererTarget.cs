using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[ExecuteInEditMode]
public class UpdateLineRendererTarget : MonoBehaviour
{
    public Transform target;
    public new LineRenderer renderer;

    private void OnEnable()
    {
        renderer = GetComponent<LineRenderer>();
    }

    void LateUpdate()
    {
        renderer.SetPosition(0, transform.parent.position);
        renderer.SetPosition(1, target.position);
    }
}
