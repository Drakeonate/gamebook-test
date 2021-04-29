using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A list that can be dynamicaly changed during runtime
/// Clears itself once the scene is loaded
/// </summary>
/// <typeparam name="T"></typeparam>
public class RuntimeSet<T> : Set<T>
{
    void OnEnable() {
        items.Clear();
    }
}
