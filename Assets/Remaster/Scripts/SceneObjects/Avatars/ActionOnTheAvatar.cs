using Data.Settings;
using UnityEngine;

[RequireComponent(typeof(AvatarData))]
public class ActionOnTheAvatar : MonoBehaviour, IDamagable
{
    private AvatarData _avatarData;

    [SerializeField]
    private BulletSettings _bulletSettingsAsHitInfo;
    public BulletSettings GetHitInfo => _bulletSettingsAsHitInfo;

    private void Start()
    {
        _avatarData = GetComponent<AvatarData>();
    }

    public void PlayAttackEffect()
    {
        _avatarData.LinkEffectsContainer.PlayAttackEffect();
    }

    public void SetDamage(int damageValue, Vector3 hit)
    {
        _avatarData.LinkEffectsContainer.PlayDamageEffect();
        _avatarData.CurentHealPoint -= damageValue;

        if (_avatarData.CurentHealPoint <= 0)
        {
            SetDestroy();
        }
    }

    private void SetDestroy()
    {
        GlobalEvents.Instance.AvatarDestroy(_avatarData);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
