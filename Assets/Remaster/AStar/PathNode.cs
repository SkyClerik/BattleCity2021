using UnityEngine;

[System.Serializable]
public class PathNode
{
    // Координаты точки на карте.
    public Vector2Int Position { get; set; }
    // Длина пути от старта (G).
    public int PathLengthFromStart { get; set; }
    // Точка, из которой пришли в эту точку.
    public PathNode CameFrom { get; set; }
    // Примерное расстояние до цели (H).
    public int HeuristicEstimatePathLength { get; set; }
    // Ожидаемое полное расстояние до цели (F).
    public int EstimateFullPathLength => PathLengthFromStart + HeuristicEstimatePathLength;
}