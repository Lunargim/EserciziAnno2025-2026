using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "gridDisplayerScriptable", menuName = "Scriptable Objects/gridDisplayerScriptable")]
public class GridDisplayerScriptable : ScriptableObject
{
    [SerializeField] public float gridCellSize;
    [SerializeField] public Vector2Int gridSize;
    public int[,] gridContentValues;
    
}
