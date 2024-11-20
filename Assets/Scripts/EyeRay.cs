using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EyeRay : MonoBehaviour
{
    [SerializeField]
    private float rayLength = 1.0f;

    [SerializeField]
    private float rayWidth = 0.1f;

    [SerializeField]
    private LayerMask layersToInclude;

    [SerializeField]
    private Color rayColorDefaultState = Color.yellow;

    [SerializeField]
    private Color rayColorHoverState = Color.grey;

    private LineRenderer lineRenderer;

    private List<EyeInteractable> eyeInteractables = new List<EyeInteractable>();
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        SetupRay();   
    }

    void SetupRay()
    {
        lineRenderer.useWorldSpace = false;
        lineRenderer.startWidth = rayWidth;
        lineRenderer.endWidth = rayWidth;
        lineRenderer.startColor = rayColorDefaultState;
        lineRenderer.endColor = rayColorDefaultState;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y, transform.position.z + rayLength));
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 rayDirection = transform.TransformDirection(Vector3.forward) * rayLength;
        
        if (Physics.Raycast(transform.position, rayDirection, out hit, Mathf.Infinity, layersToInclude))
        {
            UnSelect();
            lineRenderer.startColor = rayColorHoverState;
            lineRenderer.endColor = rayColorHoverState;
            var eyeInteractable = hit.transform.GetComponent<EyeInteractable>();
            eyeInteractables.Add(eyeInteractable);
            eyeInteractable.IsHovered = true;
            Debug.Log("hit at : " + hit.point.ToString());
        }
        else
        {
            UnSelect(true);
            lineRenderer.startColor = rayColorDefaultState;
            lineRenderer.endColor = rayColorDefaultState;
        }
    }

void UnSelect(bool clear = false)
    {
        if (eyeInteractables.Count > 0)
        {
            foreach (var eyeInteractable in eyeInteractables)
            {
                if (eyeInteractable != null)
                {
                    eyeInteractable.IsHovered = false;
                }
            }
            if (clear)
            {
                eyeInteractables.Clear();
            }
        }
    }
}
