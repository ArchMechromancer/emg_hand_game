using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_spawner : MonoBehaviour
{

    public GameObject bg;
    public float maxtime = 63;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newBG = Instantiate(bg);
        newBG.transform.position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxtime)
        {
            GameObject newBG = Instantiate(bg);
            newBG.transform.position = transform.position;
            Destroy(newBG, 90f);
            timer = 0;

        }
        timer += Time.deltaTime;
    }

}
