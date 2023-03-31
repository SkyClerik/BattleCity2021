using UnityEngine;

public class AssetSkillBase : ScriptableObject
{
    [SerializeField]
    private string _name;
    public new string name
    {
        get { return _name; }
        set { _name = value; }
    }
    //[SerializeField]
    //private Sprite _icon;
    //public Sprite icon
    //{
    //    get { return _icon; }
    //    set { _icon = value; }
    //}
    [SerializeField]
    private float _rollBackTime;
    public float rollBackTime
    {
        get { return _rollBackTime; }
        set { _rollBackTime = value; }
    }
    [SerializeField]
    private float _radius;
    public float radius
    {
        get { return _radius; }
        set { _radius = value; }
    }
    [SerializeField]
    private ApplicationArea _applicationArea;
    public ApplicationArea applicationArea
    {
        get { return _applicationArea; }
        set { _applicationArea = value; }
    }
    [SerializeField]
    private float _curentRollBack;
    public float CurentRollBack
    {
        get { return _curentRollBack; }
        set { _curentRollBack = value; }
    }
    [SerializeField]
    private bool _isReadyToUse;
    public bool isReadyToUse
    {
        get { return _isReadyToUse; }
        set { _isReadyToUse = value; }
    }
    [SerializeField]
    [Range(0.01f, 3f)]
    private float _waitTime; // Костыль верени действия эффекта
    public float waitTime
    {
        get { return _waitTime; }
        set { _waitTime = value; }
    }
}