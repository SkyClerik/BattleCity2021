using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BagListData", menuName = "Data/BagListData")]
[System.Serializable]
public class BagListData : ScriptableObject
{
    [SerializeField]
    private List<TextToggle> _bagToggles = new List<TextToggle>();
    public List<TextToggle> BagToggles => _bagToggles;
    public TextToggle ShowBags { get; set; }


    [SerializeField]
    private List<TextToggle> _plansToggles = new List<TextToggle>();
    public List<TextToggle> PlansToggles => _plansToggles;
    public TextToggle ShowPlans { get; set; }


    [SerializeField]
    private List<TextToggle> _done = new List<TextToggle>();
    public List<TextToggle> Done => _done;
    public TextToggle ShowDones { get; set; }
}

[System.Serializable]
public class TextToggle
{
    [SerializeField]
    private bool _toggle;
    public bool Toggle { get => _toggle; set => _toggle = value; }

    [SerializeField]
    private string _text;
    public string Text { get => _text; set => _text = value; }

    [SerializeField]
    private string _altText;
    public string AltText { get => _altText; set => _altText = value; }

    public TextToggle()
    {

    }

    public TextToggle(string text, string altText, bool toggle)
    {
        _text = text;
        _altText = altText;
        _toggle = toggle;
    }
}