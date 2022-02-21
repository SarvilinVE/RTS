using UnityEngine;

public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecutor where T : ICommand
{
	public void ExecuteCommand(object command) => ExecuteCommand((T)command);


	public abstract void ExecuteSpecificCommand(T command);
}