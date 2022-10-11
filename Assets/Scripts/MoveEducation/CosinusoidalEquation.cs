using UnityEngine;

public class CosinusoidalEquation : MoveEquation
{
    private Vector3 _origin;
    private Vector3 _speed;
    private float _param1;
    private float _param2;

    public CosinusoidalEquation(Vector3 origin, Vector3 speed, Vector3 param)
    {
        _origin = origin;
        _speed = speed;
        _param1 = param.x;
        _param2 = param.y;
    }

    public override Vector3 CalcPosition(float time)
        => _origin + _speed * time + _param1 * Vector3.up * Mathf.Cos(_param2 * time);
}