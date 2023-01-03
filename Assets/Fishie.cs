using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fishie : MonoBehaviour
{

    public float speed = 1f;
    private Rigidbody rig;
    public float emg_sig = 0f;
    private int sensi = 3;
    private int tresh = 2047;


    //public float current_pos = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
        rig = GetComponent<Rigidbody>();
       
    
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject firsthand = GameObject.Find("first_hand_experiment");
        emg_sig = firsthand.GetComponent<emgbt_manager>().emg_read;
        sensi = firsthand.GetComponent<Hand>().sensi;
        tresh = (sensi * 2 - 1) * 409 + sensi -1;


        //current_pos = GetComponent<Transform>().position.y - 16;// * 512 + 2047;

        if (emg_sig > tresh)
        {
            rig.velocity = Vector3.up * speed;
        }

        


    }
}
