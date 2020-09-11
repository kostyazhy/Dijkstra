using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DijkstraAlgorithm : MonoBehaviour {

    Graph _graph;

    public Vertex startVertex;
    public Vertex endVertex;

    public void Start()
    {
        _graph = FindObjectOfType<Graph>();
        FindShortestPath(startVertex, endVertex);
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
            //Debug.Log("find minVertex " + vertex.name + " " + vertex.IsUnvisited + " " + vertex.EdgesWeightSum);
            if (vertex.IsUnvisited && vertex.EdgesWeightSum < minValue) {
                minVertex = vertex;
                minValue = vertex.EdgesWeightSum;
            }
        }
        Debug.Log("minVertex " + minVertex);
        return minVertex;
    }

    /// <summary>
    /// Поиск кратчайшего пути по вершинам
    /// </summary>
    /// <param name="startVertex">Стартовая вершина</param>
    /// <param name="finishVertex">Финишная вершина</param>
    /// <returns>Кратчайший путь</returns>
    public string FindShortestPath(Vertex startVertex, Vertex finishVertex)
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
            var nextInfo = edge.connectedVertex;
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
    string GetPath(Vertex startVertex, Vertex endVertex)
    {
        string path = endVertex.name;
        while (startVertex != endVertex) {
            endVertex = endVertex.PreviousVertex;
            if(endVertex == null) {
                Debug.Log("Path no access");
                return null;
            }

            path = endVertex.name + path;
        }
        Debug.Log("Path: " + path);
        return path;
    }

}
