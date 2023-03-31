using UnityEngine;

[System.Serializable]
public class EffectContainer
{
    [SerializeField]
    private GameObject _damage;

    [SerializeField]
    private GameObject _attack;
    public GameObject Attack => _attack;


    public void PlayDamageEffect()
    {
        ParticleSystem[] particleSystems = _damage.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem item in particleSystems)
        {
            item.Play();
        }
    }

    public void PlayAttackEffect()
    {
        if (_attack.TryGetComponent(out AttackBehaviour attackBehaviour))
        {
            attackBehaviour.Play();
        }
    }
}
