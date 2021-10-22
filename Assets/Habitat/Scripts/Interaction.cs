using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    #region Serialized variables

    [SerializeField] private Camera mainCamera;

    [SerializeField] private Transform markerTransform;

    [SerializeField] private LayerMask layerMask;

    #endregion

    #region Private variables

    private bool hover = false;

    #endregion


    private void Update()
    {
        if (hover) Hover();
    }

    public void OnInteractPrimary()
    {
        hover = !hover;
    }

    public void OnInteractSecondary()
    {
    }

    private void Hover()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

#if UNITY_EDITOR
        Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.yellow);
#endif
        
        //TODO ATTENTION: This only checks for specific layers. May need a more dynamic approach in the future. Change here.
        if (Physics.Raycast(ray, out hit, 10000f, layerMask))
        {
            markerTransform.position = hit.point;
        }
    }
}