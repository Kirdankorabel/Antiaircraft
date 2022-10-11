using UnityEngine;
using UnityEngine.UI;

public class QuitPanel : MonoBehaviour
{
    [SerializeField] private GameObject _quitPanel;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;

    private void Start()
    {
        _quitButton.onClick.AddListener(() => 
        { 
            _quitPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        });
        _yesButton.onClick.AddListener(() => Application.Quit());
        _noButton.onClick.AddListener(() =>
        { 
            _quitPanel.SetActive(false);
            Time.timeScale = 1;
        });
        this.gameObject.SetActive(false);
    }
}