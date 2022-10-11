using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsPanel : MonoBehaviour
{
    [SerializeField] private MusicManager _musicManager;
    [SerializeField] private AudioSource _soundManager;
    [SerializeField] private Slider _volumeMusicSlider;
    [SerializeField] private Slider _volumeSoundSlider;
    [SerializeField] private Button _nextSongButton;
    [SerializeField] private Button _previousSongButton;
    [SerializeField] private Text _songName;

    private void Awake()
    {
        AudioController.AudioSettingsPanel = this;
        _musicManager.songChanged += (name) => _songName.text = name;
    }

    void Start()
    {
        this.gameObject.SetActive(false); 
        _musicManager.GetAudioSource.volume = _volumeMusicSlider.value;
        _soundManager.volume = _volumeSoundSlider.value;
    }

    public void SetMusicVolume() => _musicManager.GetAudioSource.volume = _volumeMusicSlider.value;
    public void SetSoundVolume() => _soundManager.volume = _volumeSoundSlider.value;

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
