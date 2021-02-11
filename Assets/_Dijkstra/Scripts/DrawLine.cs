using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class DrawLine : MonoBehaviour {
    /// <summary>
    /// Материал для ребер
    /// </summary>
    [SerializeField]
    private Material _material;
    /// <summary>
    /// Ссылка на класс графа
    /// </summary>
    [SerializeField]
    private Graph _graph;
    /// <summary>
    /// Ссылка на класс алгоритм Дейкстры
    /// </summary>
    [SerializeField]
    private DijkstraAlgorithm _dijkstra;
    /// <summary>
    /// Ссылка на компонет LineRenderer
    /// </summary>
    LineRenderer _line;

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
    }

    /// <summary>
    /// Рисуем ребра графа 
    /// </summary>
    void OnPostRender()
    {
        RenderLines();
    }

    /// <summary>
    /// Рисуем ребра графа 
    /// </summary>
    void OnDrawGizmos()
    {
        foreach (var edge in _graph.edges) 
            Handles.Label((edge.firstVertex.transform.position + edge.secondVertex.transform.position) / 2, edge.EdgeWeight.ToString());
        RenderLines();
    }

    /// <summary>
    /// Рисуем ребра графа припомощи библиотеки GL
    /// </summary>
    void RenderLines()
    {
        GL.Begin(GL.LINES);
        _material.SetPass(0);
        foreach(var edge in _graph.edges) {            
            GL.Vertex(edge.firstVertex.transform.position);
            GL.Vertex(edge.secondVertex.transform.position);
        }
        GL.End();
    }

    /// <summary>
    /// Выделяем самый короткий путь 
    /// </summary>
    /// <param name="vertexes">Список вершин для самого короткого пути</param>
    public void SelectPath(List<Vertex> vertexes)
    {
        if (vertexes == null)
            return;
        
        _line.positionCount = vertexes.Count;
        for (int i = 0; i < _line.positionCount; i++) {
            _line.SetPosition(i, vertexes[i].transform.position);
            vertexes[i].GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
