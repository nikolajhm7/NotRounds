using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursorOnCircle : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private Transform center;

    private void Update()
    {
        Vector3 dirToCursor = ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - center.position)).normalized;
        transform.position = center.position + dirToCursor * radius;
    }

    private void OnDrawGizmosSelected()
    {
        Debug.DrawCircle(center.position, radius, 10, Color.green);
    }
}
