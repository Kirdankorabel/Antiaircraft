using System;
using UnityEngine;

public class Aircraft : MonoBehaviour, IDestroyed
{
    [SerializeField] private TrajectoryRenderer _trajectoryRenderer;
    [SerializeField] private float speed;

    private MoveEquation _moveEquation;
    private float _startTime;
    private GameObject _targetPoint;

    public event Action SpawnNext;
    public event Action Destoyed;

    public Vector3 Position => transform.position;

    private void Awake()
    {
        Gun.Aircraft = this;
    }

    private void Start()
    {
        _startTime = Time.time;
        _trajectoryRenderer.ShowTrajectory(_moveEquation, 1000, 0.1f);
    }

    void FixedUpdate()
    {
        Move();
        if (transform.position.x < 0) 
            CreateNextAircraft();
    }

    private void OnCollisionEnter(Collision collision)
    {
        SpawnNext?.Invoke();
        SpawnNext = null;
        Destoyed?.Invoke();
        StartCoroutine(Waiter.WaiteCoroutine(() => Destroy(this.gameObject), 0.5f));
        this.enabled = false;
    }

    public Vector3 GetPositionOnTime(float time)
        => _moveEquation.CalcPosition(Time.time - _startTime + time);

    public TrajectoryRenderer SetTrajectoryRenderer(TrajectoryRenderer trajectoryRenderer)
        => _trajectoryRenderer = trajectoryRenderer;

    public void SetMoveEducation(MoveEquation moveEducation)
        => _moveEquation = moveEducation;

    public void SetTargetPoint(GameObject gameObject)
    {
        _targetPoint = gameObject;
        _targetPoint.gameObject.transform.position = this.transform.position;
    }

    private void Move()
    {
        float time = Time.time - _startTime;
        transform.forward = (_moveEquation.CalcPosition(time) - _moveEquation.CalcPosition(time + 0.1f)).normalized;
        transform.position = _moveEquation.CalcPosition(time);
        _targetPoint.transform.position = _moveEquation.CalcPosition(time + Gun.Time);
    }

    private void CreateNextAircraft()
    {
        SpawnNext?.Invoke();
        SpawnNext = null;
        Destoyed?.Invoke();
        StartCoroutine(Waiter.WaiteCoroutine(() => Destroy(this.gameObject), 3f));
    }
}