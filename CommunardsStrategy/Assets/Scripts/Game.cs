using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        if (elapsedTime > 3)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(soldier, spawnPosition, Quaternion.identity);
                await Task.Delay(100);
            }
        }
        if (elapsedTime > 10)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(gunner, spawnPosition, Quaternion.identity);
                await Task.Delay(100);
            }
        }
        if (elapsedTime > 20)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(cavalier, spawnPosition, Quaternion.identity);
                await Task.Delay(100);
            }
        }
        if (elapsedTime > 30)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(canon, spawnPosition, Quaternion.identity);
                await Task.Delay(100);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject battalions;
    public GameObject soldier;
    public GameObject gunner;
    public GameObject cavalier;
    public GameObject canon;

    public Vector3 spawnPosition = new Vector3(-11, -1, 89);

    private int elapsedTime = 0;
}
