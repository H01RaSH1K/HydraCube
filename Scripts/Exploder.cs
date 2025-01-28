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
            Rigidbody rigitbody;

            if (affectedObject.TryGetComponent(out rigitbody))
                rigitbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
