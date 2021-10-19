using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private SpriteRenderer Sprite = null;
    [SerializeField]
    private Color ColorPushing = new Color(1, 0, 0);
    [SerializeField]
    private bool ToggleMode = false;

    Color init_color;
    public bool is_touching = false;

    // Start is called before the first frame update
    void Start()
    {
        init_color = Sprite.color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down " + GetComponent<Transform>().name);
        if(!ToggleMode){
            Sprite.color = ColorPushing;
            is_touching = true;
        }else{
            is_touching = !is_touching;
            if(is_touching)
                Sprite.color = ColorPushing;
            else
                Sprite.color = init_color;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up " + GetComponent<Transform>().name);
        if(!ToggleMode){
            Sprite.color = init_color;
            is_touching = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
