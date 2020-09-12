using UnityEngine;

[System.Serializable]
public class Edge {
    /// <summary>
    /// Первая вершина ребра
    /// </summary>
    public Vertex firstVertex;
    /// <summary>
    /// Вторая вершина ребра
    /// </summary>
    public Vertex secondVertex;

    /// <summary>
    /// Вес ребра
    /// </summary>
    [SerializeField, Range(0, 15)]
    private int _edgeWeight;
    public int EdgeWeight
    {
        get { return _edgeWeight; }
        set { _edgeWeight = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="firstVertex">Первая вершина</param>
    /// <param name="secondVertex">Вторая вершина</param>
    /// <param name="weight">Вес ребра</param>
    public Edge(Vertex firstVertex, Vertex secondVertex, int weight)
    {
        this.firstVertex = firstVertex;
        this.secondVertex = secondVertex;
        _edgeWeight = weight;
    }
}
