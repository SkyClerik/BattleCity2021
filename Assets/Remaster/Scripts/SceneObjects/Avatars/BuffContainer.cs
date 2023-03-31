using System.Collections.Generic;

[System.Serializable]
public class BuffContainer : IUpdate
{
    public List<BuffBase> Buffs = new();

    public void Add(BuffBase buffBase, AvatarData avatarData)
    {
        if (buffBase is null)
            return;

        if (Get(buffBase) is not null)
            return;

        Buffs.Add(buffBase);
        buffBase.Init(avatarData, this);
    }

    public BuffBase Get(BuffBase buffBase)
    {
        for (int i = 0; i < Buffs.Count; i++)
        {
            if (Buffs[i].name == buffBase.name)
            {
                return Buffs[i];
            }
        }
        return null;
    }

    public void RemoveFrom(BuffBase buffBase)
    {
        for (int i = 0; i < Buffs.Count; i++)
        {
            if (Buffs[i].name == buffBase.name)
            {
                Buffs[i].Stop();
                Buffs.Remove(Buffs[i]);
            }
        }
    }

    public void Update()
    {
        for (int i = 0; i < Buffs.Count; i++)
        {
            Buffs[i].Update();
        }
    }
}
