using System;
using System.Collections;
using UnityEngine;

public class Waiter
{
    public static IEnumerator WaiteCoroutine(Action action, float time)
    {
        yield return new WaitForSeconds(time);
        action.Invoke();
    }
}
