using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public Texture2D cursor_idle;
    public Texture2D cursor_Interact0;
    public Texture2D cursor_Interact1;

    [SerializeField]
    private interactable2D obj;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursor_idle,Vector2.zero,CursorMode.ForceSoftware);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos,Vector2.one,0f,LayerMask.GetMask("Default"));
        Debug.DrawRay(pos,pos,Color.red,1f);
        if (hit.collider == null)
        {
            obj = null;
            Cursor.SetCursor(cursor_idle,Vector2.zero,CursorMode.ForceSoftware);
        }
        else
        {
            obj = hit.collider.GetComponent<interactable2D>();
            if (obj != null)
            {
                if (obj.isActiveOn()) Cursor.SetCursor(cursor_Interact1,Vector2.zero,CursorMode.ForceSoftware);
                else Cursor.SetCursor(cursor_Interact0,Vector2.zero,CursorMode.ForceSoftware);
            }
        }
    }

    public void Onclick()
    {
        if (obj == null || !obj.isActiveOn()) return;
        obj.Interact();
    }
}
