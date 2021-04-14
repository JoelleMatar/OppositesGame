using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single : MonoBehaviour
{
    [SerializeField]
    private GameObject checkedObject;
    public static bool intrus;

    // Start is called before the first frame update
    void Start()
    {
        intrus = false;
        checkedObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreLayerCollision(5, 5);
        if (Input.touchCount > 0 && !intrus)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began)
                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                {
                    checkedObject.SetActive(true);
                    intrus = true;
                }
        }
    }

    void OnMouseDown()
    {
        checkedObject.SetActive(true);
        intrus = true;
    }
}
