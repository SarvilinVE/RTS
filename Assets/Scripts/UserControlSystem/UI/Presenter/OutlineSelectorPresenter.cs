using System.Collections.Generic;
using UnityEngine;

public class OutlineSelectorPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;

    private List<ISelectable> _selectables = new List<ISelectable>();
    private ISelectable _currentSelectable;

    private void Start()
    {
        _selectable.OnNewValue += onSelected;
        onSelected(_selectable.CurrentValue);

    }
    private void onSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
            return;

        _currentSelectable = selectable;
        SetSelected(_selectables, false);

        _selectables.Clear();

        if (selectable != null)
        {
            _selectables.Add(selectable);
            selectable.DrawOutline(true);
            SetSelected(_selectables, true);
        }
    }

    private void SetSelected(List<ISelectable> selectables, bool value)
    {
        if(selectables != null)
        {
            foreach (var item in selectables)
                item.DrawOutline(value);
        }
    }
}