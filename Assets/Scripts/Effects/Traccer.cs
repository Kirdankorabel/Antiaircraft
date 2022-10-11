using UnityEngine;

public class Traccer : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private IDestroyed _target;

    public void SetTarget(IDestroyed target)
    {
        _target = target;
        target.Destoyed += () =>
        {
            _target = null;
            particleSystem.enableEmission = false;
            this.enabled = false;
        };
    }

    private void Awake()
    {
        particleSystem = this.gameObject.GetComponent<ParticleSystem>();
        StartCoroutine(Waiter.WaiteCoroutine(() => Destroy(this.gameObject), particleSystem.startLifetime));
    }

    private void Update()
    {
        transform.position = _target.Position;
    }

    public void SetColor(Color color)
        => particleSystem.startColor = color;
}