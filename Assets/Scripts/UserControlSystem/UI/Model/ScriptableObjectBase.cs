using System;
using UnityEngine;

public abstract class ScriptableObjectBase<T> : ScriptableObject, IAwaitable<T>
{
    public class NewValueNotiffer<TAwaited> : AwaiterBase<TAwaited>
    { 
        private readonly ScriptableObjectBase<TAwaited> _scriptableObjectBase;

        public NewValueNotiffer(ScriptableObjectBase<TAwaited> scriptableObjectBase)
        {
            _scriptableObjectBase = scriptableObjectBase;
            _scriptableObjectBase.OnNewValue += onNewValue;
        }
        private void onNewValue(TAwaited obj)
        {
            _scriptableObjectBase.OnNewValue -= onNewValue;
            onWaitFinish(obj);
        }
    }
    public T CurrentValue { get; private set; }
    public Action<T> OnNewValue;

    public void SetValue(T value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }

    public IAwaiter<T> GetAwaiter()
    {
        return new NewValueNotiffer<T>(this);
    }
    
}
