using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapPlacement : MonoBehaviour
{

    [Header("Prefabs")]
    [SerializeField] private GameObject tailsmanRadar;
    private GameObject currentItem;

    [Header("Spawning")]
    [SerializeField] private RectTransform radarSpawnPoint;
    [SerializeField] private Transform groundSpawnPoint;
    [SerializeField] private PlayerInteraction playerInteractions;

    private List<GameObject> activeTraps;

    private void Awake()
    {
        activeTraps = new List<GameObject>();
    }
    public void SpawnTrap()
    {
        currentItem = playerInteractions.GetComponent<PlayerInteraction>().GetItem();
        var itemProperties = currentItem.GetComponent<ItemTrigger>().ItemProperties();

        if (itemProperties.itemName == "Tailsman")
        {
            var radarTrap = Instantiate(itemProperties.spritePrefab, radarSpawnPoint.anchoredPosition, Quaternion.identity);
            radarTrap.transform.SetParent(radarSpawnPoint, false);
            Debug.Log(radarTrap);
            activeTraps.Add(radarTrap);
            Instantiate(itemProperties.itemPrefab, groundSpawnPoint.position, Quaternion.identity);
        }

        Destroy(currentItem);
    }

    public List<GameObject> GetActiveTraps() 
    {
        return activeTraps;
    }
}
