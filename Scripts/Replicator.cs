using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replicator : MonoBehaviour
{
    [SerializeField] private int _minReplicates = 2;
    [SerializeField] private int _maxReplicates = 6;

    public List<HydraCube> Replicate(HydraCube cube)
    {
        int replicatesAmount = Random.Range(_minReplicates, _maxReplicates + 1);
        List<HydraCube> replicates = new List<HydraCube>();

        for (int i = 0; i < replicatesAmount; i++)
        {
            HydraCube replicate = Instantiate(cube);
            replicate.Initialize(cube);
            replicates.Add(replicate);
        }

        return replicates;
    }
}
