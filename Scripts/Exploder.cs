using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 1f;
    [SerializeField] private float _explosionRadius = 5f;

    public void Explode(IEnumerable<GameObject> affectedObjects)
    {
        foreach (GameObject affectedObject in affectedObjects)
        {
            var rigitbody = affectedObject.GetComponent<Rigidbody>();

            if (rigitbody != null)
                rigitbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
