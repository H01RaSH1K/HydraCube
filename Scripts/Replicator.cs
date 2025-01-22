using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Renderer))]
public class Replicator : MonoBehaviour
{
    [SerializeField] private int _minReplicates = 2;
    [SerializeField] private int _maxReplicates = 6;

    [SerializeField] private float _scaleDivider = 2f;

    public List<GameObject> Replicate()
    {
        var replicatesAmount = Random.Range(_minReplicates, _maxReplicates + 1);
        List<GameObject> replicates = new List<GameObject>();

        for (int i = 0; i < replicatesAmount; i++)
            replicates.Add(InstatiateReplicate());

        return replicates;
    }

    private GameObject InstatiateReplicate()
    {
        var replicate = Instantiate(gameObject);
        replicate.transform.localPosition = GetRandomOffsetPosition();
        replicate.transform.localScale = transform.localScale / _scaleDivider;
        replicate.GetComponent<Renderer>().material.color = GetRandomColor();

        return replicate;
    }

    private Vector3 GetRandomOffsetPosition()
    {
        var origin = transform.position;
        var maxOffset = transform.localScale; 

        float offsetX = Random.Range(-maxOffset.x, maxOffset.x);
        float offsetY = Random.Range(0, maxOffset.y);
        float offsetZ = Random.Range(-maxOffset.z, maxOffset.z);

        return new Vector3(origin.x + offsetX, origin.y + offsetY, origin.z + offsetZ);
    }

    private Color GetRandomColor()
    {
        return Random.ColorHSV();
    }
}
