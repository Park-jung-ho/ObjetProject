using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public MouseType type = MouseType.idle;

    public SpriteRenderer currentCursor;
    public Color canAlpha;
    public Color cantAlpha;

    public Sprite cursor_idle;
    [FoldoutGroup("Npc")]
    public Sprite cursor_npc0;
    [FoldoutGroup("Npc")]
    public Sprite cursor_npc1;
    [FoldoutGroup("Object")]
    public Sprite cursor_Object0;
    [FoldoutGroup("Object")]
    public Sprite cursor_Object1;

    [SerializeField]
    private interactable2D obj;
    
    void Start()
    {
        // Cursor.SetCursor(cursor_idle,Vector2.zero,CursorMode.ForceSoftware);
        Cursor.visible = false;
        currentCursor = GetComponent<SpriteRenderer>();
        currentCursor.sprite = cursor_idle;
    }

    void Update()
    {
        if (Cursor.visible) Cursor.visible = false;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
        RaycastHit2D hit = Physics2D.Raycast(pos,Vector2.one,0f,LayerMask.GetMask("Default"));
        // Debug.DrawRay(pos,pos,Color.red,1f);
        if (hit.collider == null ||
            PlayerController2D.instance.CurrentState() == PlayerState.dialog)
        {
            if (type != MouseType.idle)
            {
                obj = null;
                type = MouseType.idle;
                currentCursor.sprite = cursor_idle;
                currentCursor.color = canAlpha;
            }
        }
        else
        {
            obj = hit.collider.GetComponent<interactable2D>();
            if (obj != null)
            {
                if (obj.CanClick())
                {
                    if (obj.type == interactType.NPC)
                    {
                        type = MouseType.npc1;
                        currentCursor.sprite = cursor_npc1;
                        currentCursor.color = canAlpha;
                    }
                    if (obj.type == interactType.Object)
                    {
                        type = MouseType.obj1;
                        currentCursor.sprite = cursor_Object1;
                        currentCursor.color = canAlpha;
                    }
                }
                else
                {
                    if (obj.type == interactType.NPC)
                    {
                        type = MouseType.npc1;
                        currentCursor.sprite = cursor_npc0;
                        currentCursor.color = cantAlpha;
                    }
                    if (obj.type == interactType.Object)
                    {
                        type = MouseType.obj0;
                        currentCursor.sprite = cursor_Object0;
                        currentCursor.color = cantAlpha;
                    }
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