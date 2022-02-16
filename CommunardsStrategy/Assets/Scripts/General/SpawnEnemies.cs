using UnityEngine;
using System;
using System.Threading.Tasks;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject soldierPrefab;
    public GameObject gunnerPrefab;
    public GameObject cavalierPrefab;
    public GameObject canonPrefab;
    public Vector3 spawnPosition = new Vector3(-11, -1, 0);

    private int elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ScheduleEnemySpawning", 0f, 1f);
    }

    // Spawn a variable number of enemies based on elapsed time
    private async void ScheduleEnemySpawning()
    {
        elapsedTime++;
        if (elapsedTime % 2 == 0)
            return;

        int soldierAmount = Math.Min(Math.Max(elapsedTime / 10, 2), 15);
        int gunnerAmount = Math.Min(Math.Max(elapsedTime / 20, 0), 10);;
        int cavalierAmount = Math.Min(Math.Max(elapsedTime / 35, 0), 8); ;
        int canonAmount = Math.Min(Math.Max(elapsedTime / 50, 0), 5); ;

        for (int i = 0; i < soldierAmount; i++)
        {
            Instantiate(soldierPrefab, spawnPosition, Quaternion.identity);
            await Task.Delay(100);
        }

        for (int i = 0; i < gunnerAmount; i++)
        {
            Instantiate(gunnerPrefab, spawnPosition, Quaternion.identity);
            await Task.Delay(100);
        }

        for (int i = 0; i < cavalierAmount; i++)
        {
            Instantiate(cavalierPrefab, spawnPosition, Quaternion.identity);
            await Task.Delay(100);
        }

        for (int i = 0; i < canonAmount; i++)
        {
            Instantiate(canonPrefab, spawnPosition, Quaternion.identity);
            await Task.Delay(100);
        }
    }
}