using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandCreatorBase<T> where T : ICommand
{
    public ICommandExecutor ProcessCommandExecutor(ICommandExecutor commandExecutor, Action<T> callback)
    {
        var classSpecificExexutor = commandExecutor as CommandExecutorBase<T>;

        if (classSpecificExexutor != null)
            classSpecificCommandCreation(callback);

        return commandExecutor;
    }

    protected abstract void classSpecificCommandCreation(Action<T> creationCallback);

    public virtual void ProcessCancel() { }
}
