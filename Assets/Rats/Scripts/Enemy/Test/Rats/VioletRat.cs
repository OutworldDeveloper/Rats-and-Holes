using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestianationMovement))]
public class VioletRat : Rat
{

    [SerializeField]
    private VioletPortal violetPortalPrefab;

    [SerializeField]
    private FloatParameter minPortalDelay;

    [SerializeField]
    private FloatParameter maxPortalDelay;

    [SerializeField]
    private FloatParameter maxPortals;

    [SerializeField]
    private float minPortalPositionX = 0f, maxPortalPositionX = 5f, minPortalPositionY = -3f, maxPortalPositionY = 3f;

    [SerializeField]
    private DestianationMovement destianationMovement;

    private float nextPortalTime;

    private List<VioletPortal> portals = new List<VioletPortal>();

    protected override void Awake()
    {
        base.Awake();
        destianationMovement = GetComponent<DestianationMovement>();
    }

    protected override void Start()
    {
        base.Start();
        nextPortalTime = Time.time + Random.Range(minPortalDelay.GetValue(), maxPortalDelay.GetValue());
        destianationMovement.OnDestinationReached += DestianationMovement_OnDestinationReached;
        SelectMovePosition();
    }

    private void DestianationMovement_OnDestinationReached(object sender, System.EventArgs e)
    {
        SelectMovePosition();
    }

    private void Update()
    {
        if (!isDead)
        {
            if (portals.Count < (int)maxPortals.GetValue())
            {
                if (Time.time >= nextPortalTime)
                {
                    SpawnPortal();
                }
            }
        }
    }

    private void SpawnPortal()
    {
        nextPortalTime = Time.time + Random.Range(minPortalDelay.GetValue(), maxPortalDelay.GetValue());
        Vector3 portalPosition = new Vector3(0, 0, 0);
        portalPosition.x = Random.Range(minPortalPositionX, maxPortalPositionX);
        portalPosition.y = Random.Range(minPortalPositionY, maxPortalPositionY);
        portals.Add(Instantiate(violetPortalPrefab, portalPosition, Quaternion.identity));
    }

    private void SelectMovePosition()
    {
        Vector3 movePosition = new Vector3(0, 0, 0);
        if(portals.Count >= maxPortals.GetValue())
        {
            movePosition.x = -20f;
            movePosition.y = transform.position.y;
        }
        else
        {
            movePosition.x = Random.Range(minPortalPositionX, maxPortalPositionX);
            movePosition.y = Random.Range(minPortalPositionY, maxPortalPositionY);
        }
        destianationMovement.SetDestination(movePosition);
    }

}