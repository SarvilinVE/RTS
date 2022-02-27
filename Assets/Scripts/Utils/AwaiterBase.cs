using System;

public abstract class AwaiterBase<TAwaited> : IAwaiter<TAwaited>
{
    private Action _continuation;
    private bool _isCompleted;
    private TAwaited _getResult;
    public bool IsCompleted => _isCompleted;
    public TAwaited GetResult() => _getResult;

    public void OnCompleted(Action continuation)
    {
        if (_isCompleted)
            continuation?.Invoke();
        else
            _continuation = continuation;


    }

    public void onWaitFinish(TAwaited awaited)
    {
        _getResult = awaited;
        _isCompleted = true;
        _continuation?.Invoke();
    }
}
