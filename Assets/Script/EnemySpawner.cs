using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject slimePrefab;

    private float timer;

    [SerializeField]
    private float SpawnAt;
    [SerializeField]
    private float minSpawnT;
    [SerializeField]
    private float maxSpawnT;


    // Start is called before the first frame update
    void Start()
    {
        if (maxSpawnT == 0f)
        {
            maxSpawnT = 10f;
        }

        if (minSpawnT == 0f)
        {
            minSpawnT = 1f;
        }

        SpawnAt = Random.Range(minSpawnT, maxSpawnT);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= SpawnAt)
        {
            SpawnSlime();
        }
    }

    void SpawnSlime()
    {
        //Spawn sound

        Instantiate(slimePrefab, transform.position, transform.rotation, gameObject.transform);
        SpawnAt = Random.Range(minSpawnT, maxSpawnT);
        timer = 0;
    }
}
