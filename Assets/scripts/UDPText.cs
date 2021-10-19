using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UDPText : MonoBehaviour
{
    [SerializeField]
    private string RightName;
    [SerializeField]
    private string LeftName;
    [SerializeField]
    private string ServerName;

    GameObject r_obj, l_obj, s_obj;

    // Start is called before the first frame update
    void Start()
    {
        r_obj = GameObject.Find(RightName);
        l_obj = GameObject.Find(LeftName);
        s_obj = GameObject.Find(ServerName);
    }

    // Update is called once per frame
    void Update()
    {
        string r_text = r_obj.GetComponent<Joy>().my_dist.ToString("f5");
        string l_text = l_obj.GetComponent<Joy>().my_dist.ToString("f5");
        string text = r_text + "," + l_text;
        s_obj.GetComponent<UDPSockClient>().SendData = text;
    }
}
