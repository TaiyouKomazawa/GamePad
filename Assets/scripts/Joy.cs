using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joy : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 init_pos;
    [SerializeField]
    private Vector2 limit = new Vector2(1, 1);
    [SerializeField]
    private SpriteRenderer sprite = null;

    private bool is_touching = false;

    public Vector2 my_dist = new Vector2(0, 0);

    private Color init_color;

    // Start is called before the first frame update
    void Start()
    {
        init_pos = transform.position;
        init_color = sprite.color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down "+GetComponent<Transform>().name);
        is_touching = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up " + GetComponent<Transform>().name);
        transform.position = init_pos;
        sprite.color = init_color;
        my_dist = new Vector2(0, 0);
        is_touching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(is_touching){
            for(int i = 0; i < Input.touchCount; i++){
                Touch touch = Input.GetTouch(i);
                Vector2 world_pos = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 dist = (world_pos - init_pos) / limit;

                if(i == 0 || my_dist.sqrMagnitude > dist.sqrMagnitude)
                    my_dist = dist;
            }
            my_dist.x = Mathf.Clamp(my_dist.x, -1, 1);
            my_dist.y = Mathf.Clamp(my_dist.y, -1, 1);
            sprite.color = new Color(Mathf.Abs(my_dist.x), Mathf.Abs(my_dist.y), 0);
            transform.position = init_pos + my_dist;
        }
        Debug.LogFormat("{0} {1}", my_dist.ToString("f4"), GetComponent<Transform>().name);
    }
}
