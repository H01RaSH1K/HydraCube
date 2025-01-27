using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replicator : MonoBehaviour
{
    [SerializeField] private int _minReplicates = 2;
    [SerializeField] private int _maxReplicates = 6;

    public List<GameObject> Replicate(HydraCube cube)
    {
        var replicatesAmount = Random.Range(_minReplicates, _maxReplicates + 1);
        List<GameObject> replicates = new List<GameObject>();

        for (int i = 0; i < replicatesAmount; i++)
        {
            var replicate = Instantiate(cube);
            replicate.OnReplicated(cube);
            replicates.Add(replicate.gameObject);
        }

        return replicates;
    }
}
