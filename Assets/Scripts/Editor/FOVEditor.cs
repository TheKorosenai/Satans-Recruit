using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FOVEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.forward, Vector3.up, 360, fov.viewRadius);

        Vector3 ViewAngleA = fov.DirFromAngle(-fov.viewAngle / 2, false);
        Vector3 ViewAngleB = fov.DirFromAngle(fov.viewAngle / 2, false);

        Handles.DrawLine(fov.transform.position, fov.transform.position + ViewAngleA * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + ViewAngleB * fov.viewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTarget in fov.VisibleTargets)
        {
            Handles.DrawLine(fov.transform.position, visibleTarget.position);
        }

    }
}
