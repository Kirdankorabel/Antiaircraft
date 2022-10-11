using System;
using UnityEngine;

public interface IDestroyed
{
    public event Action Destoyed;
    public Vector3 Position { get; }
}
