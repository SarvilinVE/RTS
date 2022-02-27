using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeModel
{
    IObservable<int> GameTime { get; } 
}
