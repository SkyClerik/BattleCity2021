using Data.Settings;
using UnityEngine;

public class Wall : MonoBehaviour, IDamagable
{
    [SerializeField]
    private int _healPoint = 10;
    [SerializeField]
    private BoxType _type;
    [SerializeField]
    private Material _material;

    public CustomCube _customCube;

    [SerializeField]
    private BulletSettings _bulletSettingsAsHitInfo;
    public BulletSettings GetHitInfo => _bulletSettingsAsHitInfo;

    private void Awake()
    {
        _bulletSettingsAsHitInfo = Instantiate(_bulletSettingsAsHitInfo);
        _bulletSettingsAsHitInfo.CurrentTeam = Team.Damagable;

        if (_type == BoxType.Bricks)
            _customCube = new CustomCube(_material, gameObject);
    }

    public void SetDamage(int damage, Vector3 hit)
    {
        if (_type == BoxType.Bricks)
        {
            hit.x = Mathf.Round(hit.x);
            hit.y = 0;
            hit.z = Mathf.Round(hit.z);
            if (_customCube.Hit(hit))
            {
                SetDestroy();
            }
        }
        else
        {
            _healPoint -= damage;
            if (_healPoint <= 0)
                SetDestroy();
        }
    }

    public virtual void SetDestroy()
    {
        Destroy(gameObject);
    }
}
