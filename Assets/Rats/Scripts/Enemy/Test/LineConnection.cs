using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnection : MonoBehaviour
{

    [SerializeField]
    private float step = 1f;

    [SerializeField]
    private ParticleSystem particleSystemPrefab;

    private List<Transform> currentTransforms = new List<Transform>();

    private Transform target;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            float targetObjectsCount = Vector3.Distance(transform.position, target.position) / step;
            if (currentTransforms.Count < targetObjectsCount)
            {
                Transform newTransform = Instantiate(particleSystemPrefab, Vector3.zero, Quaternion.identity).transform;
                newTransform.SetParent(this.transform);
                currentTransforms.Add(newTransform);
            }
            for (int i = 0; i < currentTransforms.Count; i++)
            {
                currentTransforms[i].position = transform.position + Vector3.Normalize(target.position - transform.position) * i * step;
                currentTransforms[i].gameObject.SetActive(i <= targetObjectsCount);
            }
        }
    }

    private void OnDestroy()
    {
        foreach (var item in currentTransforms)
        {
            Destroy(item.gameObject);
        }
    }

}