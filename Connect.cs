using UnityEngine;
using System.Collections;

public class MenuTut : MonoBehaviour
{
    private int window = 0;

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
            if (GUI.Button(new Rect(Screen.width / 2 - 100, 185, 200, 25), "Start Server"))
            {
                Network.InitializeServer(5, 25000, true);
                window = 1;

            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, 215, 200, 25), "Connect"))
            {

                Network.Connect("127.0.0.1", 25000);
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
        }
        if (window == 2)
        {
            GUI.Button(new Rect(Screen.width / 2 - 100, 185, 200, 25), "Connected");
        }
    }


}