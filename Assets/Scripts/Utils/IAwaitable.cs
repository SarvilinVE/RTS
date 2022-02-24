using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAwaitable<T>
{
    IAwaiter<T> GetAwaiter();
}
