
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]


public class Item : ScriptableObject
{
   [SerializeField] string name;
   [SerializeField] public Sprite icon;
   public ItemStats stats;
}

[Serializable]
public class ItemStats
{
   public int value;
   public int weight;
   public Vector2Int dimensions;
   public Vector2 health;
}
