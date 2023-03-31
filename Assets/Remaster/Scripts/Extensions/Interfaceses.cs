using Data.Settings;
using UnityEngine;

public interface IUpdate
{
    void Update();
}

public interface IDamagable
{
    BulletSettings GetHitInfo { get; }
    void SetDamage(int damage, Vector3 hit);
}

public interface IStateBase
{
    void UpdateState();
    void Update();
}

public interface IPooledObject
{
    void OnObjectSpawn();
    void OnObjectDestroy();
}