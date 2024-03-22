using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public MouseType type = MouseType.idle;
    public Texture2D cursor_idle;
    [FoldoutGroup("Npc")]
    public Texture2D cursor_Interact0;
    [FoldoutGroup("Npc")]
    public Texture2D cursor_Interact1;
    [FoldoutGroup("Object")]
    public Texture2D cursor_Object0;
    [FoldoutGroup("Object")]
    public Texture2D cursor_Object1;

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
            if (type != MouseType.idle)
            {
                obj = null;
                Cursor.SetCursor(cursor_idle,Vector2.zero,CursorMode.ForceSoftware);
                type = MouseType.idle;
            }
        }
        else
        {
            obj = hit.collider.GetComponent<interactable2D>();
            if (obj != null)
            {
                if (obj.CanClick())
                {
                    Cursor.SetCursor(cursor_Interact1,Vector2.zero,CursorMode.ForceSoftware);
                    type = MouseType.npc0;
                }
                else
                {
                    Cursor.SetCursor(cursor_Interact0,Vector2.zero,CursorMode.ForceSoftware);
                    type = MouseType.npc1;
                }
            }
        }
    }

    public void Onclick()
    {
        if (obj == null || !obj.CanClick()) return;
        obj.Interact();
    }
}

public enum MouseType
{
    idle,
    npc0,
    npc1,
    obj0,
    obj1,
}