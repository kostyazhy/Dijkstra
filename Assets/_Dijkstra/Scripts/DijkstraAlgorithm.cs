using System.Collections.Generic;
using UnityEngine;

public class DijkstraAlgorithm : MonoBehaviour {
    
    /// <summary>
    /// Граф
    /// </summary>
    Graph _graph;

    /// <summary>
    /// Стартовая вершина
    /// </summary>
    public Vertex startVertex;

    /// <summary>
    /// Конечная вершина
    /// </summary>
    public Vertex endVertex;

    /// <summary>
    /// Список вершин кратчайшего пути
    /// </summary>
    public List<Vertex> shortestPath;

    /// <summary>
    /// Ссылка на класс рисующий ребра графа
    /// </summary>
    public DrowLine line;

    public void Start()
    {
        if(startVertex == null || endVertex == null) {
            Debug.LogError("Start vertex or end vertex == null");
            return;
        }
        _graph = FindObjectOfType<Graph>();
        shortestPath = FindShortestPath(startVertex, endVertex);
        line.SelectPath(shortestPath);
    }

    /// <summary>
    /// Поиск непосещенной вершины с минимальным значением суммы
    /// </summary>
    /// <returns>Информация о вершине</returns>
    public Vertex FindUnvisitedVertexWithMinSum()
    {
        var minValue = int.MaxValue;
        Vertex minVertex = null;
        foreach (var vertex in _graph.Vertices) {
            if (vertex.IsUnvisited && vertex.EdgesWeightSum < minValue) {
                minVertex = vertex;
                minValue = vertex.EdgesWeightSum;
            }
        }
        return minVertex;
    }

    /// <summary>
    /// Поиск кратчайшего пути по вершинам
    /// </summary>
    /// <param name="startVertex">Стартовая вершина</param>
    /// <param name="finishVertex">Финишная вершина</param>
    /// <returns>Кратчайший путь</returns>
    public List<Vertex> FindShortestPath(Vertex startVertex, Vertex finishVertex)
    {
        startVertex.EdgesWeightSum = 0;
        while (true) {
            var current = FindUnvisitedVertexWithMinSum();
            if (current == null) {
                break;
            }

            SetSumToNextVertex(current);
        }

        return GetPath(startVertex, finishVertex);
    }

    /// <summary>
    /// Вычисление суммы весов ребер для следующей вершины
    /// </summary>
    /// <param name="vertex">Информация о текущей вершине</param>
    void SetSumToNextVertex(Vertex vertex)
    {
        vertex.IsUnvisited = false;
        foreach (var edge in vertex.Edges) {
            var nextInfo = edge.secondVertex;
            var sum = vertex.EdgesWeightSum + edge.EdgeWeight;
            if (sum < nextInfo.EdgesWeightSum) {
                nextInfo.EdgesWeightSum = sum;
                nextInfo.PreviousVertex = vertex;
            }
        }
    }

    /// <summary>
    /// Формирование пути
    /// </summary>
    /// <param name="startVertex">Начальная вершина</param>
    /// <param name="endVertex">Конечная вершина</param>
    /// <returns>Путь</returns>
    List<Vertex> GetPath(Vertex startVertex, Vertex endVertex)
    {
        List<Vertex> shortestPath = new List<Vertex> {
            endVertex
        };
        string path = endVertex.name;
        while (startVertex != endVertex) {
            endVertex = endVertex.PreviousVertex;
            if(endVertex == null) {
                Debug.Log("Path no access");
                return null;
            }
            shortestPath.Insert(0, endVertex);
            path = endVertex.name + path;
        }
        Debug.Log("Path: " + path);

        return shortestPath;
    }
}
