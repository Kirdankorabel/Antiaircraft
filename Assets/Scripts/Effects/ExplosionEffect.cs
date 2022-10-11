using System;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public static event Action<Vector3> Explosion;

    private void OnCollisionEnter(Collision collision)
    {
        Explosion?.Invoke(transform.position);
    }
}