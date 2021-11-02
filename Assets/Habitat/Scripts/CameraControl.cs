using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    #region Serialized variables

    [SerializeField] private Transform cameraRig;
    [SerializeField] private Camera viewCamera;
    [SerializeField] private float cameraSpeed = 10.0f;
    [SerializeField] private float zoomSpeed = 10.0f;

    [SerializeField] private float minX, maxX, minZ, maxZ;

    [SerializeField] private float minZoom, maxZoom;

    #endregion

    #region Private variables

    private Vector3 movementInput;

    #endregion

    private void Update()
    {
        cameraRig.position += movementInput * (Time.deltaTime * cameraSpeed);
        cameraRig.position = new Vector3(
            Mathf.Clamp(cameraRig.position.x, minX, maxX),
            cameraRig.position.y,
            Mathf.Clamp(cameraRig.position.z, minZ, maxZ));
    }

    private void AdjustZoom(float value)
    {
        viewCamera.orthographicSize += value * Time.deltaTime * zoomSpeed;
        viewCamera.orthographicSize = Mathf.Clamp(viewCamera.orthographicSize, minZoom, maxZoom);
    }

    #region Input callbacks

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        movementInput = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    public void OnZoom(InputAction.CallbackContext value)
    {
        float inputZoom = value.ReadValue<float>();

        AdjustZoom(inputZoom);
    }

    #endregion
}