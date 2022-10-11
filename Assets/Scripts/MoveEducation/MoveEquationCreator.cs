using System;
using System.Collections.Generic;
using UnityEngine;

public static class MoveEquationCreator
{
    private static List<Func<Vector3, float, MoveEquation>> _equations = new List<Func<Vector3, float, MoveEquation>>
    {
        (origin, speed) => new ParabolicEquation(origin, speed * Vector3.left, Vector3.up),
        (origin, speed) => new ParabolicEquation(origin, speed * Vector3.left, 0.5f * Vector3.up),
        (origin, speed) => new ParabolicEquation(origin, speed * Vector3.left, -0.1f * Vector3.up),
        (origin, speed) => new LineEquation(origin, speed * Vector3.left),
        (origin, speed) => new LineEquation(origin, speed * (new Vector3(-1, 0.1f, 0))),
        (origin, speed) => new LineEquation(origin, speed * (new Vector3(-1, 0.2f, 0))),
        (origin, speed) => new LineEquation(origin, speed * (new Vector3(-3, 0.1f, 0))),
        (origin, speed) => new LineEquation(origin, speed * (new Vector3(-3, 0.2f, 0))),
        (origin, speed) => new LineEquation(origin, speed * (new Vector3(-1, 0.05f, 0))),
        (origin, speed) => new LineEquation(origin, speed * (new Vector3(-1, -0.05f, 0))),
        (origin, speed) => new CosinusoidalEquation(origin, speed * new Vector3(-2f, 0.2f, 0).normalized, new Vector3(5f, 1f)),
        (origin, speed) => new CosinusoidalEquation(origin, speed * new Vector3(-2f, 0f, 0).normalized, new Vector3(10f, 2f)),
        (origin, speed) => new CosinusoidalEquation(origin, speed * new Vector3(-2f, -0.1f, 0).normalized, new Vector3(10f, 1f)),
        (origin, speed) => new CosinusoidalEquation(origin, speed * new Vector3(-2f, 0.2f, 0).normalized, new Vector3(10f, 1f)),
        (origin, speed) => new CosinusoidalEquation(origin, speed * new Vector3(-2f, 0, 0).normalized, new Vector3(10f, 1f)),
        (origin, speed) => new CosinusoidalEquation(origin, speed * new Vector3(-2f, 0.1f, 0).normalized, new Vector3(10f, 2f)),
    };

    public static MoveEquation GetMoveEquation(Vector3 origin, float speed) 
        => _equations[UnityEngine.Random.Range(0, _equations.Count)].Invoke(origin, speed);
}