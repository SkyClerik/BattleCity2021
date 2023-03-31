using UnityEngine;

public abstract class SkillBase : AssetSkillBase
{
    public abstract void Init(AvatarData avatarData);
    public abstract void Stop();
}

public enum ApplicationArea : byte
{
    Enemy,
    MySelf,
    Nothing,
}