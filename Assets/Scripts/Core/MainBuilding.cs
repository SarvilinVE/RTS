using UnityEngine;

public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable
{
	public float Health => _health;
	public float MaxHealth => _maxHealth;
	public Sprite Icon => _icon;
	public bool IsSelected => _isSelected;

	[SerializeField] private Transform _unitsParent;

	[SerializeField] private float _maxHealth = 1000;
	[SerializeField] private Sprite _icon;

	private float _health = 1000;
	private bool _isSelected;

	public override void ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
    }

    public void DrawOutline(bool value)
    {
		if (_isSelected == value)
			return;

		var outline = gameObject.GetComponent<Outline>();
		
		if (value)
			outline.OutlineWidth = 5.0f;
		else
			outline.OutlineWidth = 0.0f;

		_isSelected = value;
	}
}