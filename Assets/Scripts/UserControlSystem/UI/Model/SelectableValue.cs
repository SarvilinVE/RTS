using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
public class SelectableValue : ScriptableObject
{
	public ISelectable CurrentValue { get; private set; }
	public Action<ISelectable> OnSelected;
    public List<ISelectable> _selectables = new List<ISelectable>();

	public void SetValue(ISelectable value)
	{
		CurrentValue = value;
		OnSelected?.Invoke(value);
	}
    public void DrawingOutline(ISelectable selectable)
    {
        if (selectable != null)
        {
            _selectables.Add(selectable);
            selectable.DrawOutline();
        }
        else if (selectable == null && _selectables.Count != 0)
        {
            foreach (var item in _selectables)
                item.DrawOutline();
            _selectables.Clear();
        }
    }
}