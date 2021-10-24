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

    [SerializeField] private Builder builder;

    [SerializeField, Tooltip("Should correspond with given cellSize.")]
    private float markerSize = 1f;

    #endregion

    #region Private variables

    private InputActions _inputActions;

    private bool _hover = true;

    private int _selectedBuilding = 0;
    private int _selectedBuildingPrevious = 0;
    private GameObject[] buildingInstances;

    private Vector3 hidePos = new Vector3(-10000f, -10000f, -10000f);

    #endregion

    #region Temporary variables

    [SerializeField] private GameObject[] buildings; //Currently only two buildings are supported.

    #endregion

    private void Awake()
    {
        //Input
        _inputActions = new InputActions();
        _inputActions.Interaction.Primary.started += ctx => OnInteractPrimary();
        _inputActions.Interaction.SelectBuildingOne.started += ctx => OnSelectBuildingOne();
        _inputActions.Interaction.SelectBuildingTwo.started += ctx => OnSelectBuildingTwo();

        _inputActions.Enable();

        //Instancing
        buildingInstances = new GameObject[buildings.Length];
        for (int i = 0; i < buildings.Length; i++)
        {
            buildingInstances[i] = Instantiate(buildings[i]);
            buildingInstances[i].transform.position = hidePos;
        }
    }

    private void Update()
    {
        if (_hover) Hover();
    }

    public void OnInteractPrimary()
    {
        GameObject go = Instantiate(buildings[_selectedBuilding]);

        builder.PlaceBuilding(go, markerTransform.position, 69); //TODO: Adjust amount dynamically
        go.GetComponent<Distributor>().Setup(builder);
    }

    public void OnInteractSecondary()
    {
    }

    public void OnSelectBuildingOne()
    {
        buildingInstances[_selectedBuilding].transform.position = hidePos;
        _selectedBuilding = 0;
    }

    public void OnSelectBuildingTwo()
    {
        buildingInstances[_selectedBuilding].transform.position = hidePos;
        _selectedBuilding = 1;
    }

    /// <summary>
    /// Projects position marker onto terrain corresponding to mouse position on screen.
    /// </summary>
    private void Hover()
    {
        //Adjust marker size
        markerTransform.localScale = new Vector3(markerSize, 1, markerSize);

        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

#if UNITY_EDITOR
        Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.yellow);
#endif

        //TODO ATTENTION: This only checks for specific layers. May need a more dynamic approach in the future. Change here.
        if (Physics.Raycast(ray, out hit, 10000f, layerMask))
        {
            Vector3 placementPosition = new Vector3(
                hit.point.x,
                Builder.GetHighestPoint(hit.point, 4f, layerMask).y,
                hit.point.z);

            //Project currently selected building at cursor position.
            markerTransform.position = placementPosition;
            buildingInstances[_selectedBuilding].transform.position = placementPosition;
        }
    }
}