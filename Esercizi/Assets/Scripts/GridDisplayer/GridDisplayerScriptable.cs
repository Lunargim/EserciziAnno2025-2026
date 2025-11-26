using UnityEngine;

[CreateAssetMenu(fileName = "gridDisplayerScriptable", menuName = "Scriptable Objects/gridDisplayerScriptable")]
public class GridDisplayerScriptable : ScriptableObject
{
    [SerializeField] public float gridCellSize;
    [SerializeField] public Vector2 gridSize;
}
