using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Defines what an object needs for it to be instatiable
/// </summary>
public interface IInstantiatable
{
    GameObject Instantiate();
}
