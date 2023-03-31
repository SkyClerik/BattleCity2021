using UnityEngine;

public class SceneObject : MonoBehaviour
{
    void Start()
    {
        AStarGrid aStar = AStarGrid.Instance;
        Vector2Int vector2Int = aStar.GetPathNode(transform);
        aStar.UpdateMapInfo(vector2Int, WalkableState.NotWalkable);
    }
}
