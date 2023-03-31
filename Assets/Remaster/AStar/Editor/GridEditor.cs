using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AStarGrid))]
public class GridEditor : Editor
{
    private AStarGrid _grid;

    private void OnEnable()
    {
        _grid = (AStarGrid)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Generate grid"))
        {
            _grid.GenerateGrid();
        }
    }
}
