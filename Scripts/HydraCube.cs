using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(Renderer))]
[RequireComponent (typeof(Exploder))]
public class HydraCube : MonoBehaviour
{
    [SerializeField] private Replicator _replicator;

    [SerializeField] private float _successChance = 1f;
    [SerializeField] private float _successChanceDivider = 2f;
    [SerializeField] private float _scaleDivider = 2f;

    private Renderer _renderer;
    private Exploder _exploder;

    public void OnReplicated(HydraCube parentCube)
    {
        transform.localPosition = GetRandomOffsetPosition(parentCube);
        transform.localScale = parentCube.transform.localScale / _scaleDivider;
        _renderer.material.color = GetRandomColor();
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _exploder = GetComponent<Exploder>();
    }

    private void OnMouseDown()
    {
        var value = Random.value;

        if (_successChance > value)
        {
            _successChance /= _successChanceDivider;
            var replicates = _replicator.Replicate(this);
            _exploder.Explode(replicates);
        }

        Destroy(gameObject);
    }

    private Vector3 GetRandomOffsetPosition(HydraCube parentCube)
    {
        var origin = parentCube.transform.position;
        var maxOffset = parentCube.transform.localScale;

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
