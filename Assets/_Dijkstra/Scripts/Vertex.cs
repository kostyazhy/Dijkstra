using System.Collections.Generic;
using UnityEngine;

public class Vertex : MonoBehaviour {
    /// <summary>
    /// Список ребер
    /// </summary>
    [SerializeField]
    private List<Edge> edges;
    public List<Edge> Edges {
        get { return edges; }
        set { Edges = edges; }
    }
    /// <summary>
    /// Не посещенная вершина
    /// </summary>
    public bool IsUnvisited { get; set; }

    /// <summary>
    /// Сумма весов ребер
    /// </summary>
    public int EdgesWeightSum { get; set; }

    /// <summary>
    /// Предыдущая вершина
    /// </summary>
    public Vertex PreviousVertex { get; set; }

    void Awake () {
        IsUnvisited = true;
        EdgesWeightSum = int.MaxValue;
        PreviousVertex = null;
    }
	
    /// <summary>
    /// Добавить ребро
    /// </summary>
    /// <param name="newEdge">Ребро</param>
    public void AddEdge(Edge newEdge)
    {
        edges.Add(newEdge);
    }

    /// <summary>
    /// Добавить ребро
    /// </summary>
    /// <param name="firstVertex">Первая вершина</param>
    /// <param name="secondVertex">Вторая вершина</param>
    /// <param name="edgeWeight">Вес</param>
    public void AddEdge(Vertex firstVertex, Vertex secondVertex, int edgeWeight)
    {
        AddEdge(new Edge(firstVertex, secondVertex, edgeWeight));
    }
}
