using UnityEngine;

public class EffectCreator : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEffectPrefab;
    [SerializeField] private Traccer _traccerEffectPrefab;

    void Start()
    {
        ExplosionEffect.Explosion += (position) =>
        {
            var effect = Instantiate(_explosionEffectPrefab, position, Quaternion.identity, transform);
            StartCoroutine(Waiter.WaiteCoroutine(() => Destroy(effect.gameObject), 10));
        };
        
        TraccerEffect.Moved += (GO, color) =>
        {
            var effect = Instantiate(_traccerEffectPrefab, transform);
            effect.SetTarget(GO);
            effect.SetColor(color);
        };
    }
}
