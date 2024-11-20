using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]

public class EyeInteractable : MonoBehaviour
{
    public bool IsHovered { get; set; }

    [SerializeField]
    private UnityEvent<GameObject> onHover;

    [SerializeField]
    private Material onHoverActiveMaterial;

    [SerializeField]
    private Material onHoverInactiveMaterial;

    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = onHoverInactiveMaterial;
    }

    void Update()
    {
        if (IsHovered)
        {
            meshRenderer.material = onHoverActiveMaterial;
            onHover.Invoke(gameObject);
        }
        else
        {
            meshRenderer.material = onHoverInactiveMaterial;
        }
    }
}