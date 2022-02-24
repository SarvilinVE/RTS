using System;
using UnityEngine;

public abstract class ScriptableObjectBase<T> : ScriptableObject, IAwaitable<T>
{
    public class NewValueNotiffer<TAwaited> : IAwaiter<TAwaited>
    { 
        private readonly ScriptableObjectBase<TAwaited> _scriptableObjectBase;
        private TAwaited _result;
        private Action _continuation;
        private bool _isCompleted;

        public NewValueNotiffer(ScriptableObjectBase<TAwaited> scriptableObjectBase)
        {
            _scriptableObjectBase = scriptableObjectBase;
            _scriptableObjectBase.OnNewValue += onNewValue;
        }
        private void onNewValue(TAwaited obj)
        {
            _scriptableObjectBase.OnNewValue -= onNewValue;
            _result = obj;
            _isCompleted = true;
            _continuation?.Invoke();
        }

        public void OnCompleted(Action continuation)
        {
            if (_isCompleted)
                continuation?.Invoke();
            else
                _continuation = continuation;
        }

        TAwaited IAwaiter<TAwaited>.GetResult()
        {
            throw new NotImplementedException();
        }

        public bool IsCompleted => _isCompleted;
        public TAwaited GetResult => _result;

        


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
