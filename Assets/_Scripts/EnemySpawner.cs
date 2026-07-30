using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyOne;
    [SerializeField] private GameObject enemyTwo;
    [SerializeField] private RectTransform[] spawnPoints;
    [SerializeField] private float spawnRateEnemyOne;
    [SerializeField] private float spawnRateEnemyTwo;

    private int randomIndex;
    private bool allSpawned = false;

    

    public IEnumerator EnemyOneSpawn()
    {
       
        yield return new WaitForSeconds(spawnRateEnemyOne);

        if(spawnPoints.Length > 0)
        {
            randomIndex = Random.Range(0, spawnPoints.Length);
           
        }

        var spawnPoint = spawnPoints[randomIndex];
        var spawnedEnemy = Instantiate(enemyOne, spawnPoint.anchoredPosition, Quaternion.identity);
        spawnedEnemy.transform.SetParent(spawnPoint, false);
        spawnedEnemy.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
      

    }
}
