using System.Net.Sockets;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UDPSockClient : MonoBehaviour
{
    [SerializeField]
    public string IP_Address = "192.168.0.80";
    [SerializeField]
    private int Port = 37501;
    [SerializeField]
    private Text text_ui = null;

    private UdpClient client;

    public string SendData = "None.";

    // Start is called before the first frame update
    void Start()
    {
        client = new UdpClient();
        client.Connect(IP_Address, Port);
        if(text_ui != null){
            text_ui.text =  "UDP Socket:\n";
            text_ui.text += "   IP  :" + IP_Address + "\n";
            text_ui.text += "   Port:" + Port.ToString() + "\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!string.IsNullOrEmpty(SendData)){
           Debug.Log("DataSend");
           var message = Encoding.UTF8.GetBytes(SendData);
           client.Send(message, message.Length);
       }
    }
}
