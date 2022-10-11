using System;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource _player;
    [SerializeField] private List<AudioClip> _playlist;

    private int _currentTrek = 0;
    private float _nextClipStartTime;
    private bool _isReady;

    public event Action<string> songChanged;

    public AudioSource GetAudioSource => _player;

    private void Awake()
    {
        BundlesLoader.BundelsLoaded += () =>
        {
            _playlist = Store.GetAllAssets<AudioClip>("musics");
            Play();
            _isReady = true;
        };
    }

    private void Update()
    {
        if (_isReady && Time.time > _nextClipStartTime)
            Next();
    }

    public void Next()
    {
        _player.Stop();
        if (++_currentTrek == _playlist.Count)
            _currentTrek = 0;
        _player.clip = _playlist[_currentTrek];
        Play();
    }

    public void Pervious()
    {
        _player.Stop();
        if (--_currentTrek < 0)
            _currentTrek = _playlist.Count - 1;
        _player.clip = _playlist[_currentTrek];
        Play();
    }

    private void Play()
    {
        _nextClipStartTime = Time.time + _playlist[_currentTrek].length;
        songChanged?.Invoke(_playlist[_currentTrek].name);
        _player.PlayOneShot(_playlist[_currentTrek]);
    }
}