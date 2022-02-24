using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "AssetsInstaller", menuName = "Installers/AssetsInstaller")]
public class AssetsInstaller : ScriptableObjectInstaller<AssetsInstaller>
{
	[SerializeField] private AssetsContext _legacyContext;
	[SerializeField] private Vector3Value _groundClicksRMB;
	[SerializeField] private SelectableValue _selectables;
	[SerializeField] private AttackableValue _attackableClicksRMB;

	public override void InstallBindings()
	{
		Container.BindInstances(_legacyContext, _groundClicksRMB, _selectables, _attackableClicksRMB);
		Container.Bind<IAwaitable<IAttackable>>()
			.FromInstance(_attackableClicksRMB);
		Container.Bind<IAwaitable<Vector3>>()
			 .FromInstance(_groundClicksRMB);
	}
}