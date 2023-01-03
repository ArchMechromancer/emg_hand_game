using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArduinoBluetoothAPI;
using System;
using System.Text;



public class emgbt_manager : MonoBehaviour
{
    string deviceName;

    string message;
    private BluetoothHelper bluetoothHelper;

    public Material[] materials;

    string received_message;

    public int emg_read;

    public Text text;

    private string x;
    // Start is called before the first frame update
    void Start()
    {
        deviceName = "ESP32_EMG";
        Debug.Log($"Connecting  to {deviceName}");
        try
        {
            bluetoothHelper = BluetoothHelper.GetInstance(deviceName);
            bluetoothHelper.OnConnected += OnConnected;
            bluetoothHelper.OnConnectionFailed += OnConnectionFailed;

            //bluetoothHelper.OnDataReceived += OnMessageReceived;

            bluetoothHelper.setTerminatorBasedStream("\n"); //data terminator divide mensagens por nova linha (código no esp32 reflete isso)

            LinkedList<BluetoothDevice> ds = bluetoothHelper.getPairedDevicesList();

            foreach (BluetoothDevice d in ds)
            {
                Debug.Log($"{d.DeviceName} {d.DeviceAddress}");
            }
        }
        catch (Exception ex)
        {
            //sphere.GetComponent<Renderer>().material.color = Color.yellow; //jogo não possuí uma esfera, mas pode vir a ser útil algum gráfico representando status de conexão
            Debug.Log(ex.Message);

        }
    }



    // Update is called once per frame
    void Update()
    {
        //Synchronous method to receive messages
        if (bluetoothHelper != null)
        {
            if (bluetoothHelper.Available)
            {
                received_message = bluetoothHelper.Read();
                emg_read = int.Parse(received_message);
                Debug.Log($"{emg_read}");
            }
        }
    }

    /* void OnMessageReceived(BluetoothHelper helper)
     {
         //StartCoroutine(blinkSphere());
         received_message = helper.Read();
         Debug.Log(received_message);
         text.text = received_message;
         // Debug.Log(received_message);
     }
     */
    void OnConnected(BluetoothHelper helper)
    {
        //sphere.GetComponent<Renderer>().material.color = Color.green;
        try
        {
            helper.StartListening();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }

    }

    void OnConnectionFailed(BluetoothHelper helper)
    {
        //sphere.GetComponent<Renderer>().material.color = Color.red;
        Debug.Log("Connection Failed");
    }


    //Call this function to emulate message receiving from bluetooth while debugging on your PC.
    void OnGUI()
    {
        if (bluetoothHelper != null)
            bluetoothHelper.DrawGUI();
        else
            return;

        if (!bluetoothHelper.isConnected())
            //if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 10, Screen.height / 10, Screen.width / 5, Screen.height / 10), "Connect"))
            //{
            if (bluetoothHelper.isDevicePaired())
            {
                bluetoothHelper.Connect(); // tries to connect
            }
            else
            {
                //sphere.GetComponent<Renderer>().material.color = Color.magenta;
            }
        //}

        //if (bluetoothHelper.isConnected())
        /* if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 10, Screen.height - 2 * Screen.height / 10, Screen.width / 5, Screen.height / 10), "Disconnect"))
         {
             bluetoothHelper.Disconnect();
             //sphere.GetComponent<Renderer>().material.color = Color.blue;
         }


    /* if (bluetoothHelper.isConnected())
         if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 10, Screen.height / 10, Screen.width / 5, Screen.height / 10), "Send text"))
         {
             bluetoothHelper.SendData(new Byte[] { 0, 0, 85, 0, 85 });
             // bluetoothHelper.SendData("This is a very long long long long text");
         }
         */
    }


    void OnDestroy()
    {
        if (bluetoothHelper != null)
            bluetoothHelper.Disconnect();
    }

}
