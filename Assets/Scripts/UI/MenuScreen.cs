using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _buttonPlay;
    [SerializeField] private Button _buttonCreators;
    [SerializeField] private Button _buttonExit;

    public event UnityAction PlayButtonClick;
    public event UnityAction CreatorsButtonClick;
    public event UnityAction ExitButtonClick;

    public void Close()
    {
        _canvasGroup.alpha = 0;
        _buttonPlay.interactable = false;
        _buttonCreators.interactable = false;
        _buttonExit.interactable = false;
    }

    public void Open()
    {
        _canvasGroup.alpha = 1;
        _buttonPlay.interactable = true;
        _buttonCreators.interactable = true;
        _buttonExit.interactable = true;
    }

    private void OnEnable()
    {
        _buttonPlay.onClick.AddListener(OnButtonPlayClick);
        _buttonCreators.onClick.AddListener(OnButtonCreatorsClick);
        _buttonExit.onClick.AddListener(OnButtonExitClick);
    }

    private void OnDisable()
    {
        _buttonPlay.onClick.RemoveListener(OnButtonPlayClick);
        _buttonCreators.onClick.RemoveListener(OnButtonCreatorsClick);
        _buttonExit.onClick.RemoveListener(OnButtonExitClick);
    }
    private void OnButtonPlayClick()
    {
        PlayButtonClick?.Invoke();
    }

    private void OnButtonCreatorsClick()
    {
        CreatorsButtonClick?.Invoke();
    }

    private void OnButtonExitClick()
    {
        ExitButtonClick?.Invoke();
    }
}
