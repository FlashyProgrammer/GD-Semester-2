using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapPlacement : MonoBehaviour
{

    [Header("Prefabs")]
    [SerializeField] private GameObject tailsmanRadar;
    [SerializeField] private GameObject tailsman;
    private GameObject currentTrap;

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
        currentTrap = playerInteractions.GetComponent<PlayerInteraction>().CheckItem();

        if (currentTrap.CompareTag("Trap"))
        {
            var radarTrap = Instantiate(tailsmanRadar, radarSpawnPoint.anchoredPosition, Quaternion.identity);
            radarTrap.transform.SetParent(radarSpawnPoint, false);
            Debug.Log(radarTrap);
            activeTraps.Add(radarTrap);
            Instantiate(tailsman, groundSpawnPoint.position, Quaternion.identity);
        }

        Destroy(currentTrap);
    }

    public List<GameObject> GetActiveTraps() 
    {
        return activeTraps;
    }
}
