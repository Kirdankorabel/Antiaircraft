using System;
using UnityEngine;

public class Bullet : MonoBehaviour, IDestroyed
{
    public event Action Destoyed;

    public Vector3 Position => transform.position;

    private void Start()
    {
        StartCoroutine(Waiter.WaiteCoroutine(() => Destroy(this.gameObject), 5));
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioController.SoundManager.PlayAudioClip("Explosion");
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        Destoyed?.Invoke();
    }
}