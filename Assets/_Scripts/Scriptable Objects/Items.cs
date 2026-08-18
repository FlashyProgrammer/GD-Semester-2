using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Scriptable Objects/Items")]
public class Item : ScriptableObject
{
    [Header("Descriptors")]
    public string itemName;
    public string itemText;
    public Sprite itemIcon;

    public GameObject spritePrefab;
    public GameObject itemPrefab;

    [Header("Item Type")]
    public bool isTrap;

    public bool isMaterial;

    [Header("Item Requirements (If applicable)")]

    public Item[] requiredMaterials;




}
