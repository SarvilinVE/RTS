using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "AssetsInstaller", menuName = "Installers/AssetsInstaller")]
public class AssetsInstaller : ScriptableObjectInstaller<AssetsInstaller>
{
	[SerializeField] private AssetsContext _legacyContext;
	[SerializeField] private Vector3Value _groundClicksRMB;
	[SerializeField] private SelectableValue _selectables;
	[SerializeField] private AttackableValue _attackables;

	public override void InstallBindings()
	{
		Container.BindInstances(_legacyContext, _groundClicksRMB, _selectables, _attackables);
	}
}