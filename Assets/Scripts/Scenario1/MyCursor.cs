// Author: Cybaware - Fatima

using UnityEngine;

public class MyCursor : MonoBehaviour
/*  This class is used to maintain the custom cursor for Scenario 1.
 */
{
    private Animator cursorAnim; // custom cursor's animator

    void Start()
    {
        cursorAnim = GetComponent<Animator>();

        Cursor.visible = false; // hiding default cursor
    }

    void Update()
    {
        // aligning custom cursor with default cursor
        Vector2 cursorPos = 
            Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        if (Input.GetMouseButtonDown(0)) // if left mouse button is pressed
        {
            cursorAnim.SetTrigger("Click"); // running enlarging animation
        }
        else if (Input.GetMouseButtonUp(0)) // if left mouse button is released
        {
            cursorAnim.SetTrigger("Unclick"); // bringing back to normal size
        }
    }

    public void BringOntoScreen()
    /* This function is used to display the custom cursor for laptop screen.
     */
    {
        cursorAnim.SetBool("OnScreen", true); // changing custom cursor's
                                              // sprite from offscreen's to
                                              // onscreen's
    }
}
