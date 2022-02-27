using TMPro;
using UnityEngine;
using Zenject;
using UniRx;
using System;
using UnityEngine.UI;

public class TopPanelPresenter : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;

    [Inject]

    private void Init(ITimeModel timeModel)
    {
        timeModel.GameTime.Subscribe(seconds =>
        {
            var t = TimeSpan.FromSeconds(seconds);
            _inputField.text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
        });
    }
}
