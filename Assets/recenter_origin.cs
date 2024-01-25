using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.XR.CoreUtils;

public class recenter_origin : MonoBehaviour
{
    

    public Transform head;
    public Transform origin;
    public Transform target;

    public InputActionProperty recenter_button;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    public void Recenter()
    {
        XROrigin xrOrigin = GetComponent<XROrigin>();
        xrOrigin.MoveCameraToWorldLocation(target.position);
        xrOrigin.MatchOriginUpCameraForward(target.up, target.forward);

    }

    // Update is called once per frame
    void Update()
    {
        if(recenter_button.action.WasPressedThisFrame())
        {
            Recenter();

        }
    }
}
