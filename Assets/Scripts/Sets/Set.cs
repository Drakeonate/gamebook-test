using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A list that holds generic objects
/// </summary>
/// <typeparam name="T">Type of the items</typeparam>
public class Set<T> : ScriptableObject
{
    public List<T> items = new List<T>();
    public void Add(T t) {
        if (!items.Contains(t))
            items.Add(t);
    }

    public void Remove(T t) {
        if (items.Contains(t))
            items.Remove(t);
    }
}
