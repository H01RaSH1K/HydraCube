using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Replicator))]
[RequireComponent (typeof(Exploder))]
public class HydraCube : MonoBehaviour
{
    [SerializeField] private float _successChance = 1f;
    [SerializeField] private float _successChanceDivider = 2f;

    private Replicator _replicator;
    private Exploder _exploder;

    private void Start()
    {
        _replicator = GetComponent<Replicator>();
        _exploder = GetComponent<Exploder>();
    }

    private void OnMouseDown()
    {
        var value = Random.value;
        if (_successChance > value)
        {
            _successChance /= _successChanceDivider;
            var replicates = _replicator.Replicate();
            _exploder.Explode(replicates);
        }

        Destroy(gameObject);
    }
}
