using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    public GameObject coin;
    public float height;
    public float maxtime;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newCoin = Instantiate(coin);
        newCoin.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);

        
    }

    // Update is called once per frame
    void Update()
    {
        maxtime = PlayerPrefs.GetFloat("CoinSpawn", 2);
        if(timer > maxtime)
        {
            GameObject newCoin = Instantiate(coin);
            newCoin.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newCoin, 20f);
            timer = 0;
        }
        timer += Time.deltaTime;


        
    }
}
