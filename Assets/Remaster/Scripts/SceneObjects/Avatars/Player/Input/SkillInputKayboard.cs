using UnityEngine;

public class SkillInputKayboard : IUpdate
{
    private SkillContainer _skillContainer;
    private byte _playerNum = 0;
    private Belong _belong;
    KeyCode _code = KeyCode.None;

    public SkillInputKayboard(AvatarData avatarData, Belong belong)
    {
        _skillContainer = avatarData.LinkSkillContainer;
        _belong = belong;
        _playerNum = (byte)belong;
        _code = (KeyCode)(330 + (_playerNum * 20));
    }

    public void Update()
    {
        if (_playerNum != 0)
        {
            if (Input.GetKeyDown(_code))
            {
                _skillContainer.TryUseSkill(0);
            }
        }

        if (Input.anyKey)
        {
            switch (_belong)
            {
                case Belong.PlayerA:
                    if (Input.GetKeyDown(KeyCode.R))
                        _skillContainer.TryUseSkill(0);

                    break;

                case Belong.PlayerB:
                    if (Input.GetKeyDown(KeyCode.Keypad4))
                        _skillContainer.TryUseSkill(0);

                    break;

                case Belong.PlayerC:
                    if (Input.GetKeyDown(KeyCode.O))
                        _skillContainer.TryUseSkill(0);

                    break;
            }
        }
    }
}