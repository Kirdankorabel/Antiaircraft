using UnityEngine;

public class AircraftCreator : MonoBehaviour
{
    [SerializeField] private Aircraft _aircraftPrefab;
    [SerializeField] private GameObject _targetPoint;
    [SerializeField] private TrajectoryRenderer _trajectoryRenderer;
    [SerializeField] private Vector3 _startPosition;

    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        var position = new Vector3(_startPosition.x, _startPosition.y * (SimulationParams.GetParameter("Start position").Value + Random.Range(-0.3f, 0.3f)));
        var aircraft = Instantiate(_aircraftPrefab, position, Quaternion.identity);
        var speed = Random.Range(SimulationParams.GetParameter("Aircraft min speed").Value,
            SimulationParams.GetParameter("Aircraft max speed").Value);
        var _moveEducation = MoveEquationCreator.GetMoveEquation(position, speed * SimulationParams.multipler);

        aircraft.SetTrajectoryRenderer(_trajectoryRenderer);
        aircraft.SetTargetPoint(_targetPoint);
        aircraft.SetMoveEducation(_moveEducation);
        aircraft.SpawnNext += () => StartCoroutine(Waiter.WaiteCoroutine(() => Spawn(), 1f));
    }
}