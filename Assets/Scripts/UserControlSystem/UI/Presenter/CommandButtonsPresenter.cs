using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;

    [Inject] private CommandButtonsModel _model;

    private ISelectable _currentSelectable;

    private void Start()
    {
        _view.OnClick += _model.OnCommandButtonClicked;
        _model.OnCommandSent += _view.UnblockAllInteractions;
        _model.OnCommandCancel += _view.UnblockAllInteractions;
        _model.OnOnCommandAccepted += _view.BlockInteractions;

        _selectable.OnNewValue += OnSelected;
        OnSelected(_selectable.CurrentValue);

        //_view.OnClick += OnButtonClick;
    }

    private void OnSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
            return;

        if(_currentSelectable != null)
        {
            _model.OnSelectionChange();
        }

        _currentSelectable = selectable;

        _view.Clear();
        if (selectable != null)
        {

            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());

            _view.MakeLayout(commandExecutors);
        }
    }
    //private void OnButtonClick(ICommandExecutor commandExecutor)
    //{
    //    var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
    //    if(unitProducer != null)
    //    {
    //        unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
    //        return;
    //    }

    //    var unitAttack = commandExecutor as CommandExecutorBase<IAttackCommand>;
    //    if(unitAttack != null)
    //    {
    //        unitAttack.ExecuteSpecificCommand(_context.Inject(new AttackCommand()));
    //        return;
    //    }

    //    var unitPatrol = commandExecutor as CommandExecutorBase<IPatrolCommand>;
    //    if (unitPatrol != null)
    //    {
    //        unitPatrol.ExecuteSpecificCommand(_context.Inject(new PatrolCommand()));
    //        return;
    //    }

    //    var unitStop = commandExecutor as CommandExecutorBase<IStopCommand>;
    //    if (unitStop != null)
    //    {
    //        unitStop.ExecuteSpecificCommand(_context.Inject(new StopCommand()));
    //        return;
    //    }

    //    var unitMove = commandExecutor as CommandExecutorBase<IMoveCommand>;
    //    if (unitMove != null)
    //    {
    //        unitMove.ExecuteSpecificCommand(new MoveCommand());
    //        return;
    //    }
    //    throw new
    //        ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(OnButtonClick)}: Unknown type of commands executor: {commandExecutor.GetType().FullName}!");

    //}
}
