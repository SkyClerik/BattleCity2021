
public abstract class BuffBase : AssetBuffBase
{
    public abstract void Init(AvatarData avatarData, BuffContainer buffContainer);
    public abstract void Stop();
    public abstract void Update();
}