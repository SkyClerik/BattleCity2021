using State;
using UnityEngine;


[RequireComponent(typeof(AvatarData))]
public class BotBehaviour : MonoBehaviour
{
    private AvatarData _avatarData;

    private IStateBase _behaviourState;
    private IStateBase _attack;

    private void Start()
    {
        _avatarData = GetComponent<AvatarData>();
        _behaviourState = new PhaseOne(_avatarData);
        _attack = new AIAttack(_avatarData);

        InvokeRepeating(nameof(UpdateAIAttack), 0.5f, 0.5f);
    }

    private void UpdateAIAttack()
    {
        if (gameObject.activeSelf)
            _attack?.UpdateState();
    }

    private void Update()
    {
        _behaviourState?.Update();
    }
}
