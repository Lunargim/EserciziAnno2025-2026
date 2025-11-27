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
            var rectHorizontal = EditorGUILayout.BeginHorizontal(GUILayout.Height(gridCellSize));
            DrawHorizontalLines(rectHorizontal, gridCellSize, gridSize.x);
        }

        for (int i = 0; i < gridSize.y; i++)
        {
            var rectVertical = EditorGUILayout.BeginVertical(GUILayout.Height(gridCellSize));
            DrawVerticalLines(rectVertical, gridCellSize, gridSize.x);
        }

        void DrawHorizontalLines(Rect rect, float cellSize, float cellCount)
        {
            Handles.DrawLine(new Vector2(rect.x, rect.y), new Vector2(rect.width, rect.y)); ;
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space(cellSize);
        }    
          
        void DrawVerticalLines(Rect rect, float cellSize, float cellCount)
        {
            Handles.DrawLine(new Vector2(rect.y, rect.x + cellSize), new Vector2(rect.x + cellSize,rect.width));
            EditorGUILayout.EndVertical();
            rect.x += cellSize;
            EditorGUILayout.Space(cellSize);
        }  
    }
}
