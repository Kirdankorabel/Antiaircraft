using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private List<AudioClip> _playlist = new List<AudioClip>();
    private bool _isReady;

    private void Awake()
    {
        AudioController.SoundManager = this;
        BundlesLoader.BundelsLoaded += () =>
        {
            _playlist = Store.GetAllAssets<AudioClip>("sounds");
            _isReady = true;
        };
    }    

    public void PlayAudioClip(string audioClipName)
    {
        if (!_isReady)
            return;
        _audioSource.clip = _playlist.Find((clip) => clip.name == audioClipName);
        if (_audioSource == null)
            throw new System.Exception("Audio clip not found");
        _audioSource.Play();
    }
}