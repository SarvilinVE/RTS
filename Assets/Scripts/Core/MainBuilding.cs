using UnityEngine;

public class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
{
	public float Health => _health;
	public float MaxHealth => _maxHealth;
	public Sprite Icon => _icon;
	public bool IsSelected => _isSelected;


	[SerializeField] private GameObject _unitPrefab;
	[SerializeField] private Transform _unitsParent;

	[SerializeField] private float _maxHealth = 1000;
	[SerializeField] private Sprite _icon;

	private float _health = 1000;
	private bool _isSelected = false;

	public void ProduceUnit()
	{
		Instantiate(_unitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
	}
	public void DrawOutline()
    {
		var outline = gameObject.GetComponent<Outline>();
		if (_isSelected == false)
		{
			outline.OutlineWidth = 5.0f;
			_isSelected = true;
		}
		else
		{
			outline.OutlineWidth = 0.0f;
			_isSelected = false;
		}
	}
	
}