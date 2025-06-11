using System;
using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable,
    Resource
}

public enum EquipType
{
    None,
    Weapon,
    Helmet,
    Armor
}

public enum ConsumableType
{
    None,
    Health
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    [SerializeField, TextArea(3, 10)] public string description;
    public ItemType itemtype;
    public Sprite icon;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Equipable")]
    public EquipType equipType;
    public float atkValue;
    public float defValue;
    public float hpValue;
    public float critValue;

    [Header("Consumable")]
    public ConsumableType consumableType;
    public float value;
}
