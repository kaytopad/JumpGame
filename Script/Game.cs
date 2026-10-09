using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform spawnPoint;

    public float minIntrval = 1.0f;
    public float maxIntrval = 3.0f;

    float timer;
    float nextSpwan;
    float distance;
    float moveSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        nextSpwan = Random.Range(minIntrval, maxIntrval);
    }

    // Update is called once per frame
    void Update()
    {
        distance += moveSpeed * Time.deltaTime;

        timer += Time.deltaTime;

        if (timer >= nextSpwan) 
        {
            int index = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[index],spawnPoint.position,Quaternion.identity);

            timer = 0;
            nextSpwan = Random.Range(minIntrval, maxIntrval);
        }
    }
}
