using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IInitializationSubscriber
{
    void OnGameInitialized();
    void OnIterationInitialized();
}

