using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindLineController : MonoBehaviour
{

    [SerializeField]
    private LineRenderer lineRenderer;

    private Transform lineStartTransform;

    private Transform lineEndTransform;

    public void SetLineEndTransform(Transform lineEndTransform) {
        this.lineEndTransform = lineEndTransform;
    }

    public void SetLineStartTransform(Transform lineStartTransform) {
        this.lineStartTransform = lineStartTransform;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition (0, lineStartTransform.position);
        lineRenderer.SetPosition (1, lineEndTransform.position);
    }
}
