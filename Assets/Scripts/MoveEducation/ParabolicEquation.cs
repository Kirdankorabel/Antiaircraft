using UnityEngine;

public class ParabolicEquation : MoveEquation
{
    private Vector3 _origin;
    private Vector3 _param1;
    private Vector3 _acceleration;

    public ParabolicEquation(Vector3 origin, Vector3 param1, Vector3 acceleration)
    {
        _origin = origin;
        _param1 = param1;
        _acceleration = acceleration;
    }

    public override Vector3 CalcPosition(float time)
        => _origin + _param1 * time + _acceleration * time * time / 2f;
}
