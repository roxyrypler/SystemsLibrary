using UnityEngine;
using System.Collections.Generic;

// Required for Lists

public class GameObjectBoxTracker : MonoBehaviour
{
    public Vector3 boxHalfExtents = new Vector3(1, 1, 1);
    public float castDistance = 5.0f;
    public LayerMask layerMask; // You can set this in the Inspector to filter what the BoxCast hits

    public List<GameObject> trackedObjects = new ();

    public List<GameObject> PerformCast()
    {
        // Perform the BoxCastAll
        RaycastHit[] hits = Physics.BoxCastAll(transform.position, boxHalfExtents, transform.forward, transform.rotation, castDistance, layerMask);

        // Clear the previous list of hit objects
        trackedObjects.Clear();

        foreach (var hit in hits)
        {
            trackedObjects.Add(hit.collider.gameObject);
        }

        return trackedObjects;
    }

    // Draw Gizmos in the Editor to visualize the BoxCast
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * castDistance);

        // Draw the box from which the cast starts
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, boxHalfExtents * 2);

    }
}