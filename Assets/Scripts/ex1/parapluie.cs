using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parapluie : MonoBehaviour
{
    [SerializeField]
    private Transform objectPlace1, objectPlace2, objectPlace3;
    private Vector2 initialPos;
    private float deltaX, deltaY;
    public static bool locked;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(5, 5);
        initialPos = transform.position;
        locked = false;
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreLayerCollision(5, 5);
        if (Input.touchCount > 0 && !locked && Manager.parap)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                        Manager.volcano = false;
                        Manager.tea = false;
                        Manager.sun = false;
                        Manager.icecream = false;
                        Manager.rain = false;
                    }
                    break;

                case TouchPhase.Moved:
                    Physics.IgnoreLayerCollision(5, 5);
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    break;

                case TouchPhase.Ended:
                    Manager.volcano = true;
                    Manager.tea = true;
                    Manager.sun = true;
                    Manager.icecream = true;
                    Manager.rain = true;
                    if (!ColdCategory.full1 || !ColdCategory.full2 || !ColdCategory.full3)
                    {
                        if (!ColdCategory.full1 && Mathf.Abs(transform.position.x - objectPlace1.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - objectPlace1.position.y) <= 0.5f)
                        {
                            transform.position = new Vector2(objectPlace1.position.x, objectPlace1.position.y);
                            ColdCategory.full1 = true;
                            locked = true;
                        }
                        else if (!ColdCategory.full2 && Mathf.Abs(transform.position.x - objectPlace2.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - objectPlace2.position.y) <= 0.5f)
                        {
                            transform.position = new Vector2(objectPlace2.position.x, objectPlace2.position.y);
                            ColdCategory.full2 = true;
                            locked = true;
                        }
                        else if (!ColdCategory.full3 && Mathf.Abs(transform.position.x - objectPlace3.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - objectPlace3.position.y) <= 0.5f)
                        {
                            transform.position = new Vector2(objectPlace3.position.x, objectPlace3.position.y);
                            ColdCategory.full3 = true;
                            locked = true;
                        }
                        else
                        {
                            transform.position = new Vector2(initialPos.x, initialPos.y);
                        }
                    }
                    else
                    {
                        transform.position = new Vector2(initialPos.x, initialPos.y);
                    }
                    break;
            }
        }
    }
}
