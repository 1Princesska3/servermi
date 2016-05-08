using UnityEngine;
using System.Collections;

public class MenuTut : MonoBehaviour
{
    private int window = 0;
    private string ip = "127.0.0.1";
    private string port = "25000";
    private string MaxConnections = "20";
    // Use this for initialization
    void Start()
    {

    }
    void OnServerInitialized()
    {
        window = 1;
    }
    void OnConnectedToServer()
    {
        window = 2;
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {
        if (window == 0)
        {
            ip = GUI.TextField(new Rect(Screen.width / 2 - 100, 155, 110, 25), ip);
            port = GUI.TextField(new Rect(Screen.width / 2 + 15, 155, 55, 25), port);
            MaxConnections = GUI.TextField(new Rect(Screen.width / 2 + 75, 155, 25, 25), MaxConnections);
            if (GUI.Button(new Rect(Screen.width / 2 - 100, 185, 200, 25), "Start Server"))
            {
                Network.InitializeServer(int.Parse(MaxConnections), int.Parse(port), true);
                window = 1;

            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, 215, 200, 25), "Connect"))
            {
                Network.Connect(ip, int.Parse(port));
            }
        }
        if (window == 1)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, 215, 200, 25), "Server Shutdown"))
            {
                Network.Disconnect();
                window = 0;
            }
            GUI.Button(new Rect(Screen.width / 2 - 100, 245, 200, 25), "Connections:" + Network.connections.Length);
            if (GUI.Button(new Rect(Screen.width / 2 - 100, 275, 200, 25), "Start Room"))
            {
                GetComponent<NetworkView>().RPC﻿("LoadLevel", RPCMode.All);
            }
            if (window == 2)
            {
                GUI.Button(new Rect(Screen.width / 2 - 100, 185, 200, 25), "Connected");
            }

        }
    }
    [RPC]
    void LoadLevel()
    {
        Application.LoadLevel(1);
    }

}
