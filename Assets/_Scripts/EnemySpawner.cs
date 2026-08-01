using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawning Settings")]
    [SerializeField] private GameObject enemyOne;
    [SerializeField] private GameObject enemyTwo;
    [SerializeField] private List<RectTransform> spawnPoints;
    [SerializeField] private float spawnRateEnemyOne;
    [SerializeField] private float spawnRateEnemyTwo;
    
    [Header("Movement Ring Points")]
    [SerializeField] private List<RectTransform> ringZero;
    [SerializeField] private List<RectTransform> ringTwo;
    [SerializeField] private List<RectTransform> ringThree;
    [SerializeField] private List<RectTransform> ringFour;

    private int randomIndex;

    public IEnumerator EnemyOneSpawn()
    {
       
        yield return new WaitForSeconds(spawnRateEnemyOne);

        if(spawnPoints.Count > 0)
        {
            randomIndex = Random.Range(0, spawnPoints.Count);
           
        }

        if (spawnPoints.Count != 0)
        {
            var spawnPoint = spawnPoints[randomIndex];
            spawnPoints.RemoveAt(randomIndex);
            var spawnedEnemy = Instantiate(enemyOne, spawnPoint.anchoredPosition, Quaternion.identity);
            spawnedEnemy.transform.SetParent(spawnPoint, false);

            spawnedEnemy.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

            spawnedEnemy.GetComponent<RadarEnemy>().moveRingZero = ringZero;
            spawnedEnemy.GetComponent<RadarEnemy>().moveRingOne = ringTwo;
            spawnedEnemy.GetComponent<RadarEnemy>().moveRingTwo = ringThree;
            spawnedEnemy.GetComponent<RadarEnemy>().moveRingThree = ringFour;

        }
      
      

    }
}
