using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Edge
{
    /// <summary>
    /// Связанная вершина
    /// </summary>
    public Vertex connectedVertex;

    /// <summary>
    /// Вес ребра
    /// </summary>
    [SerializeField]
    private int _edgeWeight;
    public int EdgeWeight
    {
        get { return _edgeWeight; }
        set { _edgeWeight = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="connectedVertex">Связанная вершина</param>
    /// <param name="weight">Вес ребра</param>
    public Edge(Vertex connectedVertex, int weight)
    {
        this.connectedVertex = connectedVertex;
        _edgeWeight = weight;
    }
}
