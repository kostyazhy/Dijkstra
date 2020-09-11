using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Граф
/// </summary>
public class Graph : MonoBehaviour {

    /// <summary>
    /// Список вершин графа
    /// </summary>
    public List<Vertex> Vertices { get; set; }

    /// <summary>
    /// Находит вершины на сцене и переноситься в список
    /// </summary>
    void Awake () {
        var vertices = FindObjectsOfType<Vertex>();
        Vertices = new List<Vertex>();
        foreach (var vertex in vertices) {
            Vertices.Add(vertex);
        }
    }

    /// <summary>
    /// Добавление вершины
    /// </summary>
    /// <param name="vertexName">Имя вершины</param>
    public void AddVertex(string vertexName)
    {
        Vertices.Add(new Vertex());
    }

    /// <summary>
    /// Поиск вершины
    /// </summary>
    /// <param name="vertexName">Название вершины</param>
    /// <returns>Найденная вершина</returns>
    public Vertex FindVertex(Vertex vertex)
    {
        foreach (var v in Vertices) {
            if (v == vertex) {
                return v;
            }
        }

        return null;
    }

    /// <summary>
    /// Добавление ребра
    /// </summary>
    /// <param name="firstVertex">Первая вершина</param>
    /// <param name="secondVertex">Конечная вершина</param>
    /// <param name="weight">Вес ребра соединяющего вершины</param>
    public void AddEdge(Vertex firstVertex, Vertex secondVertex, int weight)
    {
        if (secondVertex != null && firstVertex != null) {
            firstVertex.AddEdge(secondVertex, weight);
            secondVertex.AddEdge(firstVertex, weight);
        }
    }
}
