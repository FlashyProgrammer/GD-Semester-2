using System.Collections.Generic;
using UnityEngine;

public class RadarEnemy : MonoBehaviour
{
    [Header("Enemy Movement Settings")]
    [SerializeField] private float timerCheck;
    [Range(1, 100)]
    [SerializeField] private float enemyMoveChance;

    [Header("Movement Ring Points")]
    public List<RectTransform> moveRingZero;
    public List<RectTransform> moveRingOne;
    public List<RectTransform> moveRingTwo;
    public List<RectTransform> moveRingThree;

    private RectTransform rectTransform;
    private float randomFloat;
    private bool moveEnemy;
    private float timerCounter;

    private int randomInt;
    private int currentInt;
    private int ringInt;


    private void Awake()
    {
        timerCounter = timerCheck;
        ringInt = 0;
        currentInt = 0;
        rectTransform = GetComponent<RectTransform>();
    }


    private void Update()
    {
        if (timerCounter > 0)
        {
            timerCounter -= Time.deltaTime;
        }

        else if(timerCounter < 0)
        {
            randomFloat = Random.Range(0, 1f);

            if (randomFloat <= enemyMoveChance/100)
            {
                Debug.Log("Enemy Moves Forward");

                switch (ringInt)
                {
                    case 0:
                        rectTransform.position = moveRingOne[currentInt].position;
                        rectTransform.SetParent(moveRingOne[currentInt]);
                        ringInt = 1;
                        break;
                    case 1:
                        rectTransform.position = moveRingTwo[currentInt].position;
                        rectTransform.SetParent(moveRingTwo[currentInt]);
                        ringInt = 2;
                        break;
                    case 2:
                        rectTransform.position = moveRingThree[currentInt].position;
                        rectTransform.SetParent(moveRingThree[currentInt]);
                        ringInt = 3;
                        break;
                    case 3:
                        Debug.Log("Player is dead");
                        break;
                }

            }
            else
            {
                Debug.Log("Enemy Move Back");
                switch (ringInt)
                {
                    case 0:
                        break;
                    case 1:
                        rectTransform.position = moveRingZero[currentInt].position;
                        rectTransform.SetParent(moveRingZero[currentInt]);
                        ringInt = 0;
                        break;
                    case 2:
                        rectTransform.position = moveRingOne[currentInt].position;
                        rectTransform.SetParent(moveRingOne[currentInt]);
                        ringInt = 1;
                        break;
                    case 3:
                        rectTransform.position = moveRingTwo[currentInt].position;
                        rectTransform.SetParent(moveRingTwo[currentInt]);
                        ringInt = 2;
                        break;
                }

            }
          
            timerCounter = timerCheck;
        }
        
    }

    void ShufflePoint(List<RectTransform> points)
    {
        for (int i = 0; i < points.Count; i++)
        {
            RectTransform temp = points[i];
            int randomInt = Random.Range(i, points.Count);
            points[i] = points[randomInt];
            points[randomInt] = temp;
        }
    }

}
