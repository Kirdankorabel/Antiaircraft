using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private TrajectoryRenderer _trajectory;
    [SerializeField] private float _speed = 15;

    public static Vector3[] trajectoryPoints;
    public static MoveEquation _parabolicEquation;
    public static float Time;

    private Vector3 _position;

    private void Start()
    {
        _position = transform.position;
    }

    private void FixedUpdate()
    {
        _speed = SimulationParams.GetParameter("Bullet speed").Value * SimulationParams.multipler;
        _parabolicEquation = new ParabolicEquation(_position, transform.forward * _speed, Physics.gravity);
        trajectoryPoints = _trajectory.ShowTrajectory(_parabolicEquation, 200, 0.1f);
        transform.rotation = Quaternion.LookRotation(GetDirection());
    }

    private Vector3 GetDirection()
    {
        var aircraft = GameConlroller.Aircraft;
        if (aircraft == null)
            return transform.forward;
        
        var direction = transform.position + aircraft.transform.position;
        float time;
        Vector3 delta;
        Vector3 position;
        
        for(var i = 0; i < 20; i++)
        {
            time = direction.magnitude / _speed;
            position = transform.position + _speed * direction.normalized * time + Physics.gravity * time * time / 2f;
            delta = position - aircraft.GetPositionOnTime(time);
            if (Mathf.Abs(delta.magnitude) < 0.1f)
            {
                Time = time;
                return direction;
            }
            direction = direction - delta;
        }
        return transform.forward;
    }
}