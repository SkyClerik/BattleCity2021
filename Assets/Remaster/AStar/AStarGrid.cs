using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

public class AStarGrid : Singleton<AStarGrid>
{
    [SerializeField]
    Vector2Int gridSize;
    private int[,] _map;

    [SerializeField]
    private List<Vector3> _gizmoNodes = new List<Vector3>();
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < _gizmoNodes.Count; i++)
        {
            Gizmos.DrawWireCube(_gizmoNodes[i], new Vector3(1, 0, 1));
        }
    }

    private void Awake()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        Debug.Log($"GenerateGrid");
        int i = 0;
        _map = new int[gridSize.x, gridSize.y];
        _gizmoNodes = new List<Vector3>();

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int z = 0; z < gridSize.y; z++)
            {
                _map[x, z] = 0;
                _gizmoNodes.Add(new Vector3(x, 0, z));
                i++;
            }
        }
    }

    public bool GetPath(Transform start, Transform end, out List<Vector3> path)
    {
        List<Vector2Int> path2d = FindPath(start, end);
        path = null;

        if (path2d == null)
            return false;

        path = new();
        foreach (var item in path2d)
            path.Add(new Vector3(item.x, 0, item.y));

        return true;
    }

    public void UpdateMapInfo(Vector2Int position, WalkableState walkableState)
    {
        _map[position.x, position.y] = (int)walkableState;
    }

    public Vector2Int GetPathNode(Transform transform)
    {
        Vector2Int position = Vector2Int.FloorToInt(new Vector2(transform.position.x, transform.position.z));
        return position;
    }

    private List<Vector2Int> FindPath(Transform start, Transform end)
    {
        var closedSet = new Collection<PathNode>();
        var openSet = new Collection<PathNode>();
        Vector2Int endPosition = GetPathNode(start);
        Vector2Int startPosition = GetPathNode(end);

        PathNode startNode = new()
        {
            Position = startPosition,
            CameFrom = null,
            PathLengthFromStart = 0,
            HeuristicEstimatePathLength = GetHeuristicPathLength(startPosition, endPosition),
        };

        openSet.Add(startNode);


        while (openSet.Count > 0)
        {
            // Шаг 3. Из списка точек на рассмотрение выбирается точка с наименьшим F. Обозначим ее X.
            var currentNode = openSet.OrderBy(node => node.EstimateFullPathLength).First();
            // Шаг 4. Если X — цель, то мы нашли маршрут.
            if (currentNode.Position == endPosition)
                return GetPathForNode(currentNode);
            // Шаг 5.
            openSet.Remove(currentNode);
            closedSet.Add(currentNode);
            // Шаг 6.
            foreach (var neighbourNode in GetNeighbours(currentNode, endPosition, _map))
            {
                // Шаг 7. Если Y уже находится в рассмотренных — пропускаем ее.
                if (closedSet.Count(node => node.Position == neighbourNode.Position) > 0)
                    continue;

                var openNode = openSet.FirstOrDefault(node => node.Position == neighbourNode.Position);
                // Шаг 8.
                if (openNode == null)
                    openSet.Add(neighbourNode);
                else
                  if (openNode.PathLengthFromStart > neighbourNode.PathLengthFromStart)
                {
                    // Шаг 9.
                    openNode.CameFrom = currentNode;
                    openNode.PathLengthFromStart = neighbourNode.PathLengthFromStart;
                }
            }
        }
        // Шаг 10. маршрут не существует
        return null;
    }

    private Collection<PathNode> GetNeighbours(PathNode pathNode, Vector2Int endPosition, int[,] map)
    {
        var result = new Collection<PathNode>();

        // Соседними точками являются соседние по стороне клетки.
        Vector2Int[] neighbourPoints = new Vector2Int[4];
        neighbourPoints[0] = new(pathNode.Position.x + 1, pathNode.Position.y);
        neighbourPoints[1] = new(pathNode.Position.x - 1, pathNode.Position.y);
        neighbourPoints[2] = new(pathNode.Position.x, pathNode.Position.y + 1);
        neighbourPoints[3] = new(pathNode.Position.x, pathNode.Position.y - 1);

        foreach (var point in neighbourPoints)
        {
            // Проверяем, что не вышли за границы карты.
            if (point.x < 0 || point.x >= map.GetLength(0))
                continue;
            if (point.y < 0 || point.y >= map.GetLength(1))
                continue;

            // Проверяем, что по клетке можно ходить.
            if ((map[point.x, point.y] != 0) && (map[point.x, point.y] != 1))
                continue;

            // Заполняем данные для точки маршрута.
            var neighbourNode = new PathNode()
            {
                Position = point,
                CameFrom = pathNode,
                PathLengthFromStart = pathNode.PathLengthFromStart + GetDistanceBetweenNeighbours(),
                HeuristicEstimatePathLength = GetHeuristicPathLength(point, endPosition)
            };
            result.Add(neighbourNode);
        }
        return result;
    }

    private static List<Vector2Int> GetPathForNode(PathNode pathNode)
    {
        var result = new List<Vector2Int>();
        var currentNode = pathNode;
        while (currentNode != null)
        {
            result.Add(currentNode.Position);
            currentNode = currentNode.CameFrom;
        }

        return result;
    }

    private int GetHeuristicPathLength(Vector2Int from, Vector2Int to)
    {
        return Math.Abs(from.x - to.x) + Math.Abs(from.y - to.y);
    }

    private int GetDistanceBetweenNeighbours()
    {
        return 1;
    }
}

public enum WalkableState : int
{
    Walkable = 0,
    NotWalkable = 10,
}