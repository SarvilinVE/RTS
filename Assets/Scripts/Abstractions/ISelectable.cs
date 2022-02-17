using UnityEngine;

public interface ISelectable
{
	float Health { get; }
	float MaxHealth { get; }
	Sprite Icon { get; }
	bool IsSelected { get;}
	void DrawOutline(bool value);
}
