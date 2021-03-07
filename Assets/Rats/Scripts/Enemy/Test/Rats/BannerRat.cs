using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DestianationMovement))]
public class BannerRat : Rat
{

    public UnityEvent OnFlagPlaced;

    [SerializeField]
    private BannerNew bannerPrefab;

    [SerializeField]
    private float minBannerPositionX;

    [SerializeField]
    private float maxBannerPositionX;

    [SerializeField]
    private float minBannerPositionY;

    [SerializeField]
    private float maxBannerPositionY;

    private Vector2 bannerTargetPosition;

    private bool isFlagPlaced;

    private DestianationMovement destianationMovement;

    protected override void Awake()
    {
        base.Awake();
        destianationMovement = GetComponent<DestianationMovement>();
    }

    protected override void Death()
    {
        base.Death();
        //if (!isFlagPlaced) PlaceFlag(transform.position);
    }

    protected override void Start()
    {
        base.Start();
        bannerTargetPosition = GenerateBannerPosition(minBannerPositionX, maxBannerPositionX, minBannerPositionY, maxBannerPositionY);
        destianationMovement.SetDestination(bannerTargetPosition);
        destianationMovement.OnDestinationReached += DestianationMovement_OnDestinationReached;
    }

    private void DestianationMovement_OnDestinationReached(object sender, System.EventArgs e)
    {
        if (isFlagPlaced)
        {
            Destroy(this.gameObject);
        }
        else
        {
            PlaceFlag(transform.position);
            destianationMovement.SetDestination(new Vector2(20f, 0f));
        }
    }

    private void PlaceFlag(Vector3 position)
    {
        isFlagPlaced = true;
        OnFlagPlaced.Invoke();
        Instantiate(bannerPrefab, position, Quaternion.identity);
    }

    private Vector2 GenerateBannerPosition(float minX, float maxX, float minY, float maxY)
    {
        return new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

}