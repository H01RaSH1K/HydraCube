using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _baseForce = 500f;
    [SerializeField] private float _baseRadius = 10f;

    private float ScaleFactor => transform.localScale.magnitude;
    private float Radius => _baseRadius / ScaleFactor;
    private float Force => _baseForce / ScaleFactor;

    public void Explode(IEnumerable<GameObject> affectedObjects)
    {
        foreach (GameObject affectedObject in affectedObjects)
        {
            Rigidbody rigidbody;

            if (affectedObject.TryGetComponent(out rigidbody) == false)
                continue;

            rigidbody.AddExplosionForce(Force, transform.position, Radius);
        }
    }

    public void Explode()
    {
        Collider[] affectedObjects = Physics.OverlapSphere(transform.position, Radius);
        Explode(affectedObjects.Select(obj => obj.gameObject));
    }
}
