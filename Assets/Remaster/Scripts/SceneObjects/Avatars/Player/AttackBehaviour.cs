using UnityEngine;

public class AttackBehaviour : MonoBehaviour
{
    [SerializeField]
    private AudioSource _attackAudioSource;
    public AudioSource AttackAudioSource { get => _attackAudioSource; }

    ParticleSystem[] _particleSystems;

    private void Start()
    {
        _particleSystems = GetComponentsInChildren<ParticleSystem>();
    }

    public void Play()
    {
        _attackAudioSource.Play();

        foreach (ParticleSystem item in _particleSystems)
        {
            item.Play();
        }
    }
}
