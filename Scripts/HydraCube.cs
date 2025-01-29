using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

[RequireComponent(typeof(Exploder))]
[RequireComponent(typeof(ColorChanger))]
public class HydraCube : MonoBehaviour
{
    [SerializeField] private Replicator _replicator;

    [SerializeField] private float _successChance = 1f;
    [SerializeField] private float _successChanceDivider = 2f;
    [SerializeField] private float _scaleDivider = 2f;

    private ColorChanger _colorChanger;
    private Exploder _exploder;

    public float SuccessChance => _successChance;

    private void Awake()
    {
        _colorChanger = GetComponent<ColorChanger>();
        _exploder = GetComponent<Exploder>();
    }

    private void OnMouseDown()
    {
        float value = Random.value;

        if (SuccessChance > value)
        {
            List<HydraCube> replicates = _replicator.Replicate(this);
            _exploder.Explode(replicates.Select(replicate => replicate.gameObject));
        }
        else
        {
            _exploder.Explode();
        }

        Destroy(gameObject);
    }

    public void Initialize(HydraCube parentCube)
    {
        transform.localPosition = GetRandomOffsetPosition(parentCube);
        transform.localScale = parentCube.transform.localScale / _scaleDivider;
        _successChance = parentCube.SuccessChance / _successChanceDivider;
        _colorChanger.SetRandomColor();
    }

    private Vector3 GetRandomOffsetPosition(HydraCube parentCube)
    {
        Vector3 origin = parentCube.transform.position;
        Vector3 maxOffset = parentCube.transform.localScale;

        float offsetX = Random.Range(-maxOffset.x, maxOffset.x);
        float offsetY = Random.Range(0, maxOffset.y);
        float offsetZ = Random.Range(-maxOffset.z, maxOffset.z);

        return new Vector3(origin.x + offsetX, origin.y + offsetY, origin.z + offsetZ);
    }
}
