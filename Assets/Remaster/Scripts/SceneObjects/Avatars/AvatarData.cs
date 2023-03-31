using UnityEngine;

[RequireComponent(typeof(ActionOnTheAvatar))]
public class AvatarData : MonoBehaviour
{
    [SerializeField] private Team _team;
    public Team CurTeam => _team;

    [SerializeField] private int _curentHealPoint;
    public int CurentHealPoint { get => _curentHealPoint; set => _curentHealPoint = value; }

    [SerializeField] private int _maximumHealPoint;
    public int MaximumHealPoint { get => _maximumHealPoint; set => _maximumHealPoint = value; }

    [SerializeField] private int _curentMoveSpeed;
    public int CurentMoveSpeed { get => _curentMoveSpeed; set => _curentMoveSpeed = value; }

    [SerializeField] private int _maximumMoveSpeed;
    public int MaximumMoveSpeed { get => _maximumMoveSpeed; set => _maximumMoveSpeed = value; }

    [SerializeField] private int _curentGeneratorPower;
    public int CurentGeneratorPower { get => _curentGeneratorPower; set => _curentGeneratorPower = value; }

    [SerializeField] private int _maximumGeneratorPower;
    public int MaximumGeneratorPower { get => _maximumGeneratorPower; set => _maximumGeneratorPower = value; }

    [SerializeField] private SkillContainer _skillContainer;
    public SkillContainer LinkSkillContainer { get => _skillContainer; }

    [SerializeField] private EffectContainer _effectsContainer;
    public EffectContainer LinkEffectsContainer { get => _effectsContainer; }

    [SerializeField] private BuffContainer _buffContainer;
    public BuffContainer LinkBuffContainer { get => _buffContainer; }

    private ActionOnTheAvatar _actionOnTheAvatar;
    public ActionOnTheAvatar LinkActionOnTheAvatar { get => _actionOnTheAvatar; set => _actionOnTheAvatar = value; }

    private void Awake()
    {
        _actionOnTheAvatar = GetComponent<ActionOnTheAvatar>();
        _skillContainer.Init(this);

        for (int i = 0; i < _buffContainer.Buffs.Count; i++)
        {
            _buffContainer.Buffs[i] = Instantiate(_buffContainer.Buffs[i]);
            _buffContainer.Buffs[i].Init(this, _buffContainer);
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(UpdateSkillContainer), 0.5f, 0.5f);
    }

    private void UpdateSkillContainer()
    {
        _skillContainer?.Update();
    }

    private void Update()
    {
        _buffContainer.Update();
    }
}