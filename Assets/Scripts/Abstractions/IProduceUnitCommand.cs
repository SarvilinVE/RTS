using UnityEngine;

public interface IProduceUnitCommand : ICommand
{
    public GameObject UnitPrefab { get; }
}