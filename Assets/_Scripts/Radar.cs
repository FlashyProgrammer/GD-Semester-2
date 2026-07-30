using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] private GameObject radarToShow;
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private float spawnTimer;

    private float spawnCounter;
    private bool radarOnScreen;


    private void Awake()
    {
        spawnCounter = spawnTimer;
    }
    private void Update()
    {
        Debug.Log(spawnCounter);
        if (spawnCounter > 0 && radarOnScreen)
        {
            spawnCounter -= Time.deltaTime;
        }

        else if (spawnCounter < 0)
        {
            if (spawner != null)
            {
                StartCoroutine(spawner.EnemyOneSpawn());
                spawnCounter = spawnTimer;
            }

        }

    }
    public void showRadar() 
    {
        if (!radarOnScreen)
        {
            radarToShow.SetActive(true);
            radarOnScreen = true;
        }
       
             
    }

    public void hideRadar()
    {
        if (radarOnScreen)
        {
            radarToShow.SetActive(false);
            radarOnScreen = false;
        }
    }
}
