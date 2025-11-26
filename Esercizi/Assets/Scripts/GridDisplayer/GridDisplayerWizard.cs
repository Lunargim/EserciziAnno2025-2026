using UnityEditor;
using UnityEngine;

public class GridDisplayerWizard : EditorWindow
{
    public GridDisplayerScriptable gridDisplayerScriptable;
    public float gridCellSize;
    public Vector2 gridSize;
    
    [MenuItem("Tools/Grid Displayer")]
    public static void ShowWindow()
    {
        GetWindow(typeof(GridDisplayerWizard));
    }
    void OnGUI()
    {
        gridDisplayerScriptable = EditorGUILayout.ObjectField("Grid Displayer",  gridDisplayerScriptable, typeof(ScriptableObject), true) as GridDisplayerScriptable;
        if (gridDisplayerScriptable != null)
        {
            gridCellSize = gridDisplayerScriptable.gridCellSize;
            gridSize = gridDisplayerScriptable.gridSize;
        }
        gridCellSize = EditorGUILayout.FloatField("Grid Cell Size", gridCellSize);
        gridSize = EditorGUILayout.Vector2Field("Grid Size", gridSize);
        
        for (int i = 0; i < gridSize.x; i++)
        {
            //var rectHorizontal = EditorGUILayout.BeginHorizontal();
            var rectVertical = EditorGUILayout.BeginVertical();
            //DrawHorizontalLines(rectHorizontal);
            DrawVerticalLines(rectVertical);
        }

        void DrawHorizontalLines(Rect rect)
        {
            Handles.DrawLine(new Vector2(rect.x, rect.y), new Vector2(rect.width, rect.y));
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
        }    
          
        void DrawVerticalLines(Rect rect)
        {
            Handles.DrawLine(new Vector2(rect.x, rect.y), new Vector2(rect.width, rect.y));
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
        }   
            
    }
}
