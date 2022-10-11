using UnityEngine;

public class LineEquation : MoveEquation
{
    private Vector3 _origin;
    private Vector3 _param1;

    public LineEquation(Vector3 origin, Vector3 param1)
    {
        _origin = origin;
        _param1 = param1;
    }

    public override Vector3 CalcPosition(float time)
        => _origin + _param1 * time;
}