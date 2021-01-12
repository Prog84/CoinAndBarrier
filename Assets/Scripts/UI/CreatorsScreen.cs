using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CreatorsScreen : MonoBehaviour
{
    [SerializeField] private Button _buttonBack;

    public event UnityAction BackButtonClick;

    private void OnEnable()
    {
        _buttonBack.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _buttonBack.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        BackButtonClick?.Invoke();
    }
}
