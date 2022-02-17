using UnityEngine;

public class UnitChomper : MonoBehaviour, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public bool IsSelected => _isSelected;

    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;

    private float _health = 100;
    private bool _isSelected;


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
