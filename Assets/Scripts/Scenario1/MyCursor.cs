using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCursor : MonoBehaviour
{
    private Animator cursorAnim;
    private SpriteRenderer cursorRend;

    public bool onScreen;
    public SpriteRenderer screenCursorRend;

    void Start()
    {
        onScreen = false;
        cursorAnim = GetComponent<Animator>();
        Cursor.visible = false;

        cursorRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint
            (Input.mousePosition);
        transform.position = cursorPos;

        if (onScreen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                cursorAnim.SetBool("Enlarged", true);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                cursorAnim.SetBool("Enlarged", false);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                cursorAnim.SetBool("OffScreenEnlarged", true);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                cursorAnim.SetBool("OffScreenEnlarged", false);
            }
        }   
    }
}
