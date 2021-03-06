﻿
using UnityEditor;
using UnityEngine;

namespace BlueGraph.Editor
{
    /// <summary>
    /// Build a basic window container for the BlueGraph canvas
    /// </summary>
    public class GraphEditorWindow : EditorWindow
    {
        public CanvasView Canvas { get; protected set; }

        public Graph Graph { get; protected set; }

        /// <summary>
        /// Load a graph asset in this window for editing
        /// </summary>
        public void Load(Graph graph)
        {
            Graph = graph;
            
            Canvas = new CanvasView(this);
            Canvas.Load(graph);
            
            rootVisualElement.Add(Canvas);
        
            titleContent = new GUIContent(graph.name);
            Repaint();
        }

        private void Update()
        {
            Canvas.Update();
        }

        /// <summary>
        /// Restore an already opened graph after a reload of assemblies
        /// </summary>
        private void OnEnable()
        {
            if (Graph)
            {
                Load(Graph);
            }
        }
    }
}
