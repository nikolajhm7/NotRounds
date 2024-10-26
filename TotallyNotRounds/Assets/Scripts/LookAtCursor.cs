using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    [SerializeField] private Transform from;
    [SerializeField] private Vector2 fromDir;

    private void Update()
    {
        Vector2 dirToCursor = ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - from.position)).normalized;
        transform.eulerAngles = Vector3.forward * Utility.LookInDirRotation(dirToCursor, fromDir);
    }
}
