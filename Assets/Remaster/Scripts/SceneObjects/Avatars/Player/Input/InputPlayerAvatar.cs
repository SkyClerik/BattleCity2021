using UnityEngine;

[RequireComponent(typeof(AvatarData))]
public class InputPlayerAvatar : MonoBehaviour
{
    [SerializeField]
    private Belong _belong;
    public Belong BelongPlayer { get => _belong; set => _belong = value; }

    private AvatarData _avatarData;
    private SkillInputKayboard _skillInputKayboard;
    private MoveInput _moveInput;

    private void Start()
    {
        _avatarData = GetComponent<AvatarData>();
        _skillInputKayboard = new SkillInputKayboard(_avatarData, _belong);
        _moveInput = new MoveInput(_avatarData, _belong);
        AvatarCollection.SetPlayer(_avatarData, _belong);
    }

    private void Update()
    {
        _skillInputKayboard?.Update();
    }

    private void FixedUpdate()
    {
        _moveInput?.Update();
    }
}