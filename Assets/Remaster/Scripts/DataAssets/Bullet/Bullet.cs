using Data.Settings;
using UnityEngine;

public class Bullet : MonoBehaviour, IDamagable
{
    [SerializeField]
    private float _speed = 9f;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private BulletSettings _bulletSettings;
    private Vector3 _half = new Vector3(0.3f, 0.3f, 0.3f);

    [SerializeField]
    private BulletSettings _bulletSettingsAsHitInfo;
    public BulletSettings GetHitInfo => _bulletSettingsAsHitInfo;

    public void Init(AvatarData avatarData)
    {
        _bulletSettings = Instantiate(_bulletSettings);
        _bulletSettings.CurrentTeam = avatarData.CurTeam;

        Invoke(nameof(BackToPool), 4f);
    }

    private void Update()
    {
        Vector3 direction = transform.position + transform.forward;
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, direction, step);

        RaycastHit[] hits = Physics.BoxCastAll(transform.position, _half, transform.forward, Quaternion.identity, 0.1f);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.TryGetComponent(out IDamagable damagable))
            {
                if (damagable.GetHitInfo.CurrentTeam != _bulletSettings.CurrentTeam)
                {
                    if (hits[i].collider.gameObject != this.gameObject)
                    {
                        damagable.SetDamage(_damage, transform.forward);
                        BackToPool();
                    }
                }
            }
        }
    }

    private void BackToPool()
    {
        CancelInvoke(nameof(BackToPool));
        gameObject.SetActive(false);
    }

    public void SetDamage(int damage, Vector3 hit)
    {
        BackToPool();
    }
}
