using UnityEngine;

[System.Serializable]
public class PathNode
{
    // ���������� ����� �� �����.
    public Vector2Int Position { get; set; }
    // ����� ���� �� ������ (G).
    public int PathLengthFromStart { get; set; }
    // �����, �� ������� ������ � ��� �����.
    public PathNode CameFrom { get; set; }
    // ��������� ���������� �� ���� (H).
    public int HeuristicEstimatePathLength { get; set; }
    // ��������� ������ ���������� �� ���� (F).
    public int EstimateFullPathLength => PathLengthFromStart + HeuristicEstimatePathLength;
}