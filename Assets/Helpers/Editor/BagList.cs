using UnityEngine;
using UnityEditor;

public class BagList : EditorWindow
{
    #region Constructor
    [MenuItem("Help/VSK/BagList")]
    public static void ShowWindow()
    {
        BagList vse = EditorWindow.GetWindow<BagList>("BagList");
        vse.minSize = new Vector2(400, 300);
    }
    #endregion Constructor

    [SerializeField]
    private BagListData _bagListData;

    private void OnEnable()
    {
        _bagListData.ShowPlans = new TextToggle("Show", "Hide", true);
        _bagListData.ShowBags = new TextToggle("Show", "Hide", true);
        _bagListData.ShowDones = new TextToggle("Show", "Hide", true);
    }

    private void OnGUI()
    {
        if (_bagListData)
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button(_bagListData.ShowPlans.Text, GUILayout.MaxWidth(80)))
            {
                TextToggle bagToggle = _bagListData.ShowPlans;
                bagToggle.Toggle = !bagToggle.Toggle;
                (bagToggle.Text, bagToggle.AltText) = (bagToggle.AltText, bagToggle.Text);
            }
            GUILayout.Box("Известные баги");
            GUILayout.EndHorizontal();
            if (_bagListData.ShowPlans.Toggle)
            {
                for (int i = 0; i < _bagListData.BagToggles.Count; i++)
                {
                    TextToggle bagToggle = _bagListData.BagToggles[i];
                    bagToggle.Toggle = GUILayout.Toggle(bagToggle.Toggle, new GUIContent(text: bagToggle.Text, tooltip: bagToggle.AltText));
                }
            }


            GUILayout.BeginHorizontal();
            if (GUILayout.Button(_bagListData.ShowBags.Text, GUILayout.MaxWidth(80)))
            {
                TextToggle bagToggle = _bagListData.ShowBags;
                bagToggle.Toggle = !bagToggle.Toggle;
                (bagToggle.Text, bagToggle.AltText) = (bagToggle.AltText, bagToggle.Text);
            }
            GUILayout.Box("В планах");
            GUILayout.EndHorizontal();
            if (_bagListData.ShowBags.Toggle)
            {
                for (int i = 0; i < _bagListData.PlansToggles.Count; i++)
                {
                    TextToggle bagToggle = _bagListData.PlansToggles[i];
                    bagToggle.Toggle = GUILayout.Toggle(bagToggle.Toggle, new GUIContent(text: bagToggle.Text, tooltip: bagToggle.AltText));
                }
            }

            GUILayout.BeginHorizontal();
            if (GUILayout.Button(_bagListData.ShowDones.Text, GUILayout.MaxWidth(80)))
            {
                TextToggle bagToggle = _bagListData.ShowDones;
                bagToggle.Toggle = !bagToggle.Toggle;
                (bagToggle.Text, bagToggle.AltText) = (bagToggle.AltText, bagToggle.Text);
            }
            GUILayout.Box("Реализовано");
            GUILayout.EndHorizontal();
            if (_bagListData.ShowDones.Toggle)
            {
                for (int i = 0; i < _bagListData.Done.Count; i++)
                {
                    TextToggle bagToggle = _bagListData.Done[i];
                    bagToggle.Toggle = GUILayout.Toggle(bagToggle.Toggle, new GUIContent(text: bagToggle.Text, tooltip: bagToggle.AltText));
                }
            }
        }
    }
}