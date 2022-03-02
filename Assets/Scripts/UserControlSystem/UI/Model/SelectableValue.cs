using UnityEngine;

[CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
public class SelectableValue : StatefulScriptableObjectValueBase<ISelectable>
{
	
    //public void DrawingOutline(ISelectable selectable)
    //{
    //    if (selectable != null)
    //    {
    //        _selectables.Add(selectable);
    //        selectable.DrawOutline();
    //    }
    //    else if (selectable == null && _selectables.Count != 0)
    //    {
    //        foreach (var item in _selectables)
    //            item.DrawOutline();
    //        _selectables.Clear();
    //    }
    //}
}