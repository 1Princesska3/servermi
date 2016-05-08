using UnityEngine;
using System.Collections;

public class MenuTut : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 100, 185, 200, 25), "Start Server"))
        {
            Network.InitializeServer(5, 25000, true);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 100, 215, 200, 25), "Connect"))
        {

            Network.Connect("127.0.0.1", 25000);
        }
        GUI.Button(new Rect(Screen.width / 2 - 100, 245, 200, 25), "Connections:" + Network.connections.Length);
    }

}
