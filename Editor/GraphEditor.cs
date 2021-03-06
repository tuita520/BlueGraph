﻿
using UnityEngine;
using UnityEditor;

namespace BlueGraph.Editor
{
    /// <summary>
    /// Basic inspector that adds a button to edit the graph.
    /// 
    /// Typically, you should build your own inspectors that
    /// open an instance of GraphEditorWindow for the asset.
    /// </summary>
    [CustomEditor(typeof(Graph), true)]
    public class GraphEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Edit Graph"))
            {
                CreateOrFocusEditorWindow();    
            }
        
            base.OnInspectorGUI();
        }

        /// <summary>
        /// Find an existing GraphEditorWindow for the target Graph.
        /// </summary>
        /// <returns></returns>
        public GraphEditorWindow GetExistingEditorWindow()
        {
            var graph = target as Graph;

            var windows = Resources.FindObjectsOfTypeAll<GraphEditorWindow>();
            foreach (var window in windows)
            {
                if (window.Graph == graph)
                {
                    return window;
                }
            }

            return null;
        }

        /// <summary>
        /// Create a new editor window
        /// </summary>
        /// <returns></returns>
        public virtual GraphEditorWindow CreateEditorWindow()
        {
            var window = CreateInstance<GraphEditorWindow>();
            window.Show();
            window.Load(target as Graph);
            return window;
        }
        
        /// <summary>
        /// Focus the existing editor or create a new one for the target Graph
        /// </summary>
        /// <returns></returns>
        public GraphEditorWindow CreateOrFocusEditorWindow()
        {
            var window = GetExistingEditorWindow();
            if (!window)
            {
                window = CreateEditorWindow();
            }
            
            window.Focus();
            return window;
        }
    }
}
