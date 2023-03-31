using System.Collections.Generic;
using UnityEngine;

public class AudioPool : Singleton<AudioPool>
{
    [SerializeField] 
    private AudioSource _startGame;
    [SerializeField] 
    private AudioSource _gameOver;


    [SerializeField] 
    private AudioSource _moveAudioSource;
    [SerializeField] 
    private AudioSource _engineAudioSource;
    private Dictionary<Belong, MoveInput> _movers = new Dictionary<Belong, MoveInput>();

    public void Move(Belong belong, MoveInput moveInput)
    {
        _movers.TryAdd(belong, moveInput);
    }

    public void Stop(Belong belong)
    {
        _movers.Remove(belong);
    }

    private void PlayMove()
    {
        _engineAudioSource.Stop();

        if (_moveAudioSource.isPlaying == false)
            _moveAudioSource.Play();
    }

    private void PlayEngine()
    {
        if (_engineAudioSource.isPlaying == false)
            _engineAudioSource.Play();

        _moveAudioSource.Stop();
    }

    private void FixedUpdate()
    {
        if (_movers.Count == 0)
        {
            PlayEngine();
        }
        else
        {
            PlayMove();
        }
    }

    public void PlayStartGame()
    {
        _startGame.Play();
    }

    public void PlayGameOver()
    {
        _gameOver.Play();
    }
}
