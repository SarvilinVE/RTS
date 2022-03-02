using TMPro;
using UnityEngine;
using Zenject;
using UniRx;
using System;
using UnityEngine.UI;

public class TopPanelPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private Button _menuButton;
    [SerializeField] private GameObject _menuGameObject;

    [Inject]

    private void Init(ITimeModel timeModel)
    {
        timeModel.GameTime.Subscribe(seconds =>
        {
            var t = TimeSpan.FromSeconds(seconds);
            _timeText.text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
        });
        _menuButton.OnClickAsObservable().Subscribe(_ => _menuGameObject.SetActive(true));
    }
}
