using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncreaseElapsedTime", 0f, 1f);
    }

    private async void IncreaseElapsedTime()
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
            Instantiate(soldier, spawnPosition, Quaternion.identity);
            await Task.Delay(100);
        }

        for (int i = 0; i < gunnerAmount; i++)
        {
            Instantiate(gunner, spawnPosition, Quaternion.identity);
            await Task.Delay(100);
        }

        for (int i = 0; i < cavalierAmount; i++)
        {
            Instantiate(cavalier, spawnPosition, Quaternion.identity);
            await Task.Delay(100);
        }

        for (int i = 0; i < canonAmount; i++)
        {
            Instantiate(canon, spawnPosition, Quaternion.identity);
            await Task.Delay(100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject soldier;
    public GameObject gunner;
    public GameObject cavalier;
    public GameObject canon;

    public Vector3 spawnPosition = new Vector3(-11, -1, 0);

    private int elapsedTime = 0;
}
