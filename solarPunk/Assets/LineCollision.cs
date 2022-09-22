using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class LineCollision : MonoBehaviour
{
    EdgeCollider2D collider;
    LineRenderer line;

    private void Start()
    {
        collider = this.GetComponent<EdgeCollider2D>();
        line = this.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        SetEdgeCollider(line);
    }

    void SetEdgeCollider(LineRenderer render)
    {
        List<Vector2> edges = new List<Vector2>();

        for (int point = 0; point < line.positionCount; point++)
        {
            Vector3 lineRenderPoint = line.GetPosition(point++);
            edges.Add(new Vector2(lineRenderPoint.x, lineRenderPoint.y));
        }

    }

}
