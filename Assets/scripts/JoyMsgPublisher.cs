using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using JoyMsg = RosMessageTypes.Sensor.JoyMsg;

public class JoyMsgPublisher : MonoBehaviour
{
    [SerializeField]
    private string ObjectNameRightJoy;
    [SerializeField]
    private string ObjectNameLeftJoy;
    [SerializeField]
    private string[] ObjectNameButton;

    GameObject rs_obj, ls_obj;

    JoyMsg joy;

    // Start is called before the first frame update
    ROSConnection ros;
    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<JoyMsg>("android/joy");
        rs_obj = GameObject.Find(ObjectNameRightJoy);
        ls_obj = GameObject.Find(ObjectNameLeftJoy);
        joy = new JoyMsg();
    }

    // Update is called once per frame
    void Update()
    {
        GetButton();
        GetAxes();
        ros.Publish("android/joy", joy);
    }

    void GetButton()
    {
        int num = ObjectNameButton.Length;
        int[] array = new int[num];
        for(int i = 0; i < num; i++){
            GameObject obj = GameObject.Find(ObjectNameButton[i]);
            int val = obj.GetComponent<Button>().is_touching ? 1 : 0;
            array[i] = val;
        }
        joy.buttons = array;
    }

    void GetAxes()
    {
        Vector2 right = rs_obj.GetComponent<Joy>().my_dist;
        Vector2 left = ls_obj.GetComponent<Joy>().my_dist;
        float[] array = new float[4];
        array[0] = right.x;
        array[1] = right.y;
        array[2] = left.x;
        array[3] = left.y;
        joy.axes = array;
    }
}
