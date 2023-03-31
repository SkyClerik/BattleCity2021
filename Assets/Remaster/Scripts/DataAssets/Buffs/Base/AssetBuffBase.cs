using UnityEngine;

public class AssetBuffBase : ScriptableObject
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
    private float _radius;
    public float radius
    {
        get { return _radius; }
        set { _radius = value; }
    }
    [SerializeField]
    private float _curentRollBack;
    public float curentRollBack
    {
        get { return _curentRollBack; }
        set { _curentRollBack = value; }
    }
}
