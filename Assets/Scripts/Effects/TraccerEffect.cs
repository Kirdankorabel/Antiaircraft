using System;
using UnityEngine;

public class TraccerEffect : MonoBehaviour
{
    [SerializeField] private Color _color;

    public static event Action<IDestroyed, Color> Moved;

    void Start()
    {
        Moved?.Invoke(this.gameObject.GetComponent<IDestroyed>(), _color);
    }
}
