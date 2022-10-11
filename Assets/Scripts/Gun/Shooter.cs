using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Button _shotButton;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Gun _gun;

    void Start()
    {
        _shotButton.onClick.AddListener(() => Shoted());
    }

    private void Shoted()
    {
        for (var i = 0; i < SimulationParams.GetParameter("Fire density").Value; i++)
            StartCoroutine(Waiter.WaiteCoroutine(() => Shot(), i * 0.03f));
    }

    private void Shot()
    {
        AudioController.SoundManager.PlayAudioClip("Start");
        var offset = (1 - Random.Range(SimulationParams.GetParameter("Accuracy").Value, 1)) * Vector3.right
            + (1 - Random.Range(SimulationParams.GetParameter("Accuracy").Value, 1)) * Vector3.left;
        var speed = (transform.forward + offset) * SimulationParams.GetParameter("Bullet speed").Value * SimulationParams.multipler;
        Rigidbody bulletRB = Instantiate(_bulletPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRB.AddForce(speed, ForceMode.VelocityChange);
    }
}
