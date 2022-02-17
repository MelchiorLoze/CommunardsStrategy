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
        // Calls ScheduleEnemySpawning() every 1 second
        InvokeRepeating("ScheduleEnemySpawning", 0f, 1f);
    }

    // Spawn a variable number of enemies based on elapsed time
    private void ScheduleEnemySpawning()
    {
        elapsedTime++;

        // Makes units spawn only every 2 seconds
        if (elapsedTime % 2 == 0)
            return;

        // Calculate the number of unit to spawn
        int soldierAmount  = Math.Min(Math.Max(elapsedTime / 10, 2), 15); // between 2 and 15
        int gunnerAmount   = Math.Min(Math.Max(elapsedTime / 20, 0), 10); // between 0 and 10
        int cavalierAmount = Math.Min(Math.Max(elapsedTime / 35, 0), 8);  // between 0 and 8
        int canonAmount    = Math.Min(Math.Max(elapsedTime / 50, 0), 5);  // between 0 and 5

        // Spawn the units
        SpawnUnits(soldierPrefab, soldierAmount);
        SpawnUnits(gunnerPrefab, gunnerAmount);
        SpawnUnits(cavalierPrefab, cavalierAmount);
        SpawnUnits(canonPrefab, canonAmount);
    }

    // Spawns the given unit in the given quantity at the spawn position
    private async void SpawnUnits(GameObject unit, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(unit, spawnPosition, Quaternion.identity);
            // Await 100ms between each spawn to avoid total overlapping
            await Task.Delay(100);
        }
    }
}