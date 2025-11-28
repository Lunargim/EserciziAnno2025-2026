using UnityEditor;
using UnityEngine;

public class GridDisplayerWizard : EditorWindow
{
    public GridDisplayerScriptable gridDisplayerScriptable;
    public float gridCellSize;
    public Vector2Int gridSize;
    private Vector2 _scrollPosition;
    public int[,] values;
    bool hasChanged = false;

    [MenuItem("Tools/Grid Displayer")]
    public static void ShowWindow()
    {
        GetWindow(typeof(GridDisplayerWizard));
    }

    void OnGUI()
    {
        gridDisplayerScriptable =
            EditorGUILayout.ObjectField("Grid Displayer", gridDisplayerScriptable, typeof(ScriptableObject), true) as
                GridDisplayerScriptable;
        if (gridDisplayerScriptable != null)
        {
            gridCellSize = gridDisplayerScriptable.gridCellSize;
            gridSize = gridDisplayerScriptable.gridSize;
            
            if (gridDisplayerScriptable.gridContentValues != null)
            {
                values = gridDisplayerScriptable.gridContentValues;
            }
            else
            {
                values = new int[gridSize.x, gridSize.y];
                gridDisplayerScriptable.gridContentValues = values;
            }
        }

        gridCellSize = EditorGUILayout.FloatField("Grid Cell Size", gridCellSize);
        gridSize = EditorGUILayout.Vector2IntField("Grid Size", gridSize);

        if (gridDisplayerScriptable != null)
        {
            hasChanged = gridDisplayerScriptable.gridCellSize != gridCellSize ||
                         gridDisplayerScriptable.gridSize != gridSize;
            gridDisplayerScriptable.gridCellSize = gridCellSize;
            gridDisplayerScriptable.gridSize = gridSize;
            
            if (hasChanged)
            {
                values = new int[gridSize.x, gridSize.y];
                EditorUtility.SetDirty(gridDisplayerScriptable);
                AssetDatabase.SaveAssets();
            }
            
        }

        _scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
        
        for (int y = 0; y < gridSize.y; y++)
        {
            GUILayout.BeginHorizontal();
            for (int x = 0; x < gridSize.x; x++) //draw row
            {
                if (gridDisplayerScriptable.gridContentValues.GetLength(0) <= x ||
                    gridDisplayerScriptable.gridContentValues.GetLength(1) <= y)
                {
                    values[x,y] = 0;
                }
                else
                {
                    values[x,y] = gridDisplayerScriptable.gridContentValues[x,y];
                }
                
                GUILayout.Button(values[x,y].ToString(), GUILayout.Height(gridCellSize), GUILayout.Width(gridCellSize));
                EditorUtility.SetDirty(gridDisplayerScriptable);
            }
            GUILayout.EndHorizontal();
        }
        gridDisplayerScriptable.gridContentValues = values;
        GUILayout.EndScrollView();
    }
    
}