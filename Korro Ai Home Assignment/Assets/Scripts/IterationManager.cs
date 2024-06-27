using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// Initializes a new iteration every time the player dies.
/// Built upon the 'observer' design pattern.
/// </summary>
public class IterationManager
{
    public event Action OnIterationInitialize;
    public void InitializeIteration()
    {
        OnIterationInitialize?.Invoke();
    }
}