using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Vertex : MonoBehaviour {

    /// <summary>
    /// Список ребер
    /// </summary>
    [SerializeField]
    private List<Edge> _edges;
    public List<Edge> Edges {
        get { return _edges; }
        set { Edges = _edges; }
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
        _edges.Add(newEdge);
    }

    /// <summary>
    /// Добавить ребро
    /// </summary>
    /// <param name="vertex">Вершина</param>
    /// <param name="edgeWeight">Вес</param>
    public void AddEdge(Vertex vertex, int edgeWeight)
    {
        AddEdge(new Edge(vertex, edgeWeight));
    }

    /// <summary>
    /// Нарисовать ребра и подписать их веса
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (_edges == null)
            return;
        foreach (var edge in _edges) {
            if (edge.connectedVertex == null)
                continue;
            Gizmos.DrawLine(transform.position, edge.connectedVertex.transform.position);
            Handles.Label((transform.position + edge.connectedVertex.transform.position) / 2, edge.EdgeWeight.ToString());
        }
    }
}
