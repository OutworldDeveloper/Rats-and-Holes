using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{

    [SerializeField]
    private Player player;

    [SerializeField]
    private Transform shootStartPosition;

    [SerializeField]
    private ShootVisual linePrefab;

    [SerializeField]
    private Cowboy cowboy;

    [SerializeField]
    private PostProcessController postProcessController;

    [SerializeField]
    private AudioManager audioManager;

    private void Start()
    {
        player.OnPlayerShooted += Player_OnPlayerShooted;
        player.OnDeadeyeStart += Player_OnDeadeyeStart;
    }

    private void OnDestroy()
    {
        player.OnPlayerShooted -= Player_OnPlayerShooted;
        player.OnDeadeyeStart -= Player_OnDeadeyeStart;
    }

    private void Player_OnDeadeyeStart(bool started)
    {
        postProcessController.Enable(started);
        audioManager.StartDeadeye(started);
    }

    private void Player_OnPlayerShooted(RaycastHit2D hit)
    {
        cowboy.Shoot();

        Hittable hittable = hit.transform.GetComponent<Hittable>();
        if (hittable != null)
        {
            ParticleSystem hitEffect = Instantiate(hittable.GetHitEffect(), hit.point, Quaternion.identity);
            Destroy(hitEffect.gameObject, 2f);
        }

        if(player.isDeadeye && !Application.isMobilePlatform)
        {
            //Instantiate(linePrefab, Vector3.zero, Quaternion.identity).Setup(shootStartPosition.position, hit.point);
        }
    }

}