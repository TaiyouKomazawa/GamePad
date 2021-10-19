using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyText : MonoBehaviour
{
    [SerializeField]
    private string ObjectName;
    [SerializeField]
    private Text text_ui = null;
    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find(ObjectName);
    }

    // Update is called once per frame
    void Update()
    {
        text_ui.text = obj.GetComponent<Joy>().my_dist.ToString("f4");
    }
}
