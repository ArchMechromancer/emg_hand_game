using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class puppet_hand : MonoBehaviour
{

    public float speed = 3000;
    Animator animator;
    public float gripTarget;
    public float gripCurrent;
    public float emgtarg;
    public int sensi = 3;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        GameObject firsthand = GameObject.Find("first_hand_experiment");
        gripTarget = firsthand.GetComponent<emgbt_manager>().emg_read;
        sensi = firsthand.GetComponent<Hand>().sensi;

        if (gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            emgtarg = gripCurrent / 4096;
            animator.SetFloat("EMG_Read", emgtarg);
            animator.SetInteger("Sensitivity", sensi);
        }
    }
}
