using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private CreatorsScreen _creatorsScreen;
    [SerializeField] private Animator _animatorCreatorsScreen;

    private string _menuShow = "Show";

    private void OnEnable()
    {
        _menuScreen.PlayButtonClick += OnPlayButtonClick;
        _menuScreen.CreatorsButtonClick += OnCreatorsButtonClick;
        _menuScreen.ExitButtonClick += OnExitButtonClick;
        _creatorsScreen.BackButtonClick += OnBackButtonClick;
    }

    private void OnDisable()
    {
        _menuScreen.PlayButtonClick -= OnPlayButtonClick;
        _menuScreen.CreatorsButtonClick -= OnCreatorsButtonClick;
        _menuScreen.ExitButtonClick -= OnExitButtonClick;
        _creatorsScreen.BackButtonClick -= OnBackButtonClick;
    }

    private void OnPlayButtonClick()
    {
        SceneManager.LoadScene("Level");
    }

    private void OnCreatorsButtonClick()
    {
        _menuScreen.Close();
        _animatorCreatorsScreen.SetBool(_menuShow, true);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void OnBackButtonClick()
    {
        _animatorCreatorsScreen.SetBool(_menuShow, false);
        _menuScreen.Open();
    }
}
