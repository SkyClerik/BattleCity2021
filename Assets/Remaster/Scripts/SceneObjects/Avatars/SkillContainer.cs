using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillContainer : IUpdate
{
    public List<SkillBase> SkillAssets;
    [HideInInspector]
    public SkillBase CurentSkill = null;
    private AvatarData _avatarData;

    public void Init(AvatarData avatarData)
    {
        _avatarData = avatarData;

        if (SkillAssets.Count == 0)
        {
            Debug.LogError("У этого Avatar нет навыков", _avatarData.gameObject);
        }
        else
        {
            CurentSkill = SkillAssets[0];
            for (int i = 0; i < SkillAssets.Count; i++)
            {
                SkillAssets[i] = Object.Instantiate(SkillAssets[i]);
                SkillAssets[i].Stop();
            }
        }
    }

    public void Update()
    {
        UpdateSkillTime();
    }

    private void UpdateSkillTime()
    {
        foreach (SkillBase skill in SkillAssets)
        {
            if (skill.isReadyToUse == false)
            {
                skill.CurentRollBack--;

                if (skill.CurentRollBack <= 0)
                {
                    skill.Stop();
                }
            }
        }
    }

    public void TryUseSkill(int skillNumber)
    {
        CurentSkill = SkillAssets[skillNumber];

        if (CurentSkill.isReadyToUse == true)
        {
            CurentSkill.Init(_avatarData);
        }
    }
}
