using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distributor : MonoBehaviour
{
    [SerializeField] private LayerMask lm;
    [SerializeField] private float distributionRadius = 40f;

    private Collider[] colliders = new Collider[16];

    private Builder builder;

    public bool WasActivated { get; private set; } = false;

    public void Setup(Builder builder)
    {
        this.builder = builder;
        Distribute(distributionRadius);
    }

    /// <summary> Activates nearby distributors and triggers changes in the environment. </summary>
    /// <param name="radius"> Radius around distributor that is checked for other distributors. </param>
    private void Distribute(float radius)
    {
        Physics.OverlapSphereNonAlloc(transform.position, radius, colliders, lm);

        List<Distributor> distributors = new List<Distributor>();

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i] == null) break;

            Distributor db = colliders[i].GetComponent<Distributor>();

            if (db == null) continue;

            if (db.WasActivated) continue;

            db.Activate();
            distributors.Add(db);

            Debug.Log("Distributed number: " + i);
        }

        //Determine affected areas for each available distributor
        for (int i = 0; i < distributors.Count; i++)
        {
            Build(distributors[i]);
        }
    }

    private void Activate()
    {
        WasActivated = true;
    }

    private void Build(Distributor distributor)
    {
        Vector3 distributorPos = distributor.transform.position;
        float distance = Vector3.Distance(transform.position, distributorPos);

        //TODO: The following parameters used for distribution calculation should be looked up from a central data set!
        float greeneryDistance = 40f;

        float radiusGreenery = 0;
        int amountUrban = 0;

        //Urban growth
        if (distance < greeneryDistance)
        {
            amountUrban = (int) (10f * distributionRadius / distance);
            amountUrban = Mathf.Clamp(amountUrban, 4, 200);
        }
        //Nature growth
        else
        {
            radiusGreenery = distance;
        }

        builder.PlaceFoundations(transform, transform.position, amountUrban);
        builder.PlaceFoundations(distributor.transform, distributorPos, amountUrban);
    }
}