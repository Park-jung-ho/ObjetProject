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

    [SerializeField]
    private interactable2D obj;
    public string objname;

    public Sprite cursor_idle;
    [FoldoutGroup("Npc")]
    public Sprite cursor_npc0;
    [FoldoutGroup("Npc")]
    public Sprite cursor_npc1;
    [FoldoutGroup("Object")]
    public Sprite cursor_Object0;
    [FoldoutGroup("Object")]
    public Sprite cursor_Object1;
    [FoldoutGroup("Door")]
    public Sprite cursor_Door0;
    [FoldoutGroup("Door")]
    public Sprite cursor_Door1;
    [FoldoutGroup("sign")]
    public Sprite cursor_sign;
    [FoldoutGroup("tree")]
    public Sprite cursor_tree;
    [FoldoutGroup("search")]
    public Sprite cursor_search;

    public bool DontChangeCursor;

    void Start()
    {
        // Cursor.SetCursor(cursor_idle,Vector2.zero,CursorMode.ForceSoftware);
        Cursor.visible = false;
        // currentCursor = GetComponent<SpriteRenderer>();
        currentCursor.sprite = cursor_idle;
    }

    void Update()
    {
        if (Cursor.visible) Cursor.visible = false;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
        if (type == MouseType.search)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitt;
            if (Physics.Raycast(ray, out hitt))
            {
                // Debug.Log(hitt.transform.name);
                obj = hitt.collider.GetComponent<interactable2D>();
                if (obj != null)
                {
                    objname = hitt.collider.name;
                    if (obj.type == interactType.Object)
                    {
                        type = MouseType.obj1;
                        currentCursor.sprite = cursor_Object1;
                        currentCursor.color = canAlpha;
                    }
                }
                else
                {
                    if (type != MouseType.idle)
                    {
                        obj = null;
                        objname = "";
                        type = MouseType.idle;
                        currentCursor.sprite = cursor_idle;
                        currentCursor.color = canAlpha;
                    }
                }
                return;
            }
        }




        RaycastHit2D[] hits = Physics2D.RaycastAll(pos,Vector2.zero,Mathf.Infinity,LayerMask.GetMask("Default"));
        obj = null;
        objname = "";
        foreach (RaycastHit2D hit in hits)
        {
            if (obj != null) break;
            obj = hit.collider.GetComponent<interactable2D>();
            objname = hit.collider.name;
        }
        // Debug.DrawRay(pos,pos,Color.red,1f);
        if (obj == null ||
            DontChangeCursor ||
            PlayerController2D.instance.CurrentState(PlayerState.dialog) ||
            PlayerController2D.instance.CurrentState(PlayerState.sign))
        {
            if (type != MouseType.idle)
            {
                obj = null;
                objname = "";
                type = MouseType.idle;
                currentCursor.sprite = cursor_idle;
                currentCursor.color = canAlpha;
            }
        }
        else
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
                if (obj.type == interactType.Door)
                {
                    type = MouseType.obj1;
                    currentCursor.sprite = cursor_Door1;
                    currentCursor.color = canAlpha;
                }
                if (obj.type == interactType.sign)
                {
                    type = MouseType.sign;
                    currentCursor.sprite = cursor_sign;
                    currentCursor.color = canAlpha;
                }
                if (obj.type == interactType.tree)
                {
                    if (InventoryManager.instance.selectItemID != "axe") return;
                    type = MouseType.tree;
                    currentCursor.sprite = cursor_tree;
                    currentCursor.color = canAlpha;
                }
                if (obj.type == interactType.search)
                {
                    if (InventoryManager.instance.selectItemID != "search") return;
                    type = MouseType.search;
                    currentCursor.sprite = cursor_search;
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
                if (obj.type == interactType.Door)
                {
                    type = MouseType.obj0;
                    currentCursor.sprite = cursor_Door0;
                    currentCursor.color = cantAlpha;
                }
                if (obj.type == interactType.sign)
                {
                    type = MouseType.sign;
                    currentCursor.sprite = cursor_sign;
                    currentCursor.color = cantAlpha;
                }
                if (obj.type == interactType.tree)
                {
                    if (InventoryManager.instance.selectItemID != "axe") return;
                    type = MouseType.tree;
                    currentCursor.sprite = cursor_tree;
                    currentCursor.color = cantAlpha;
                }
                if (obj.type == interactType.search)
                {
                    if (InventoryManager.instance.selectItemID != "search") return;
                    type = MouseType.search;
                    currentCursor.sprite = cursor_search;
                    currentCursor.color = cantAlpha;
                }
            }
            
        }
    }
    
    public void Onclick()
    {
        if (obj == null || !obj.CanClick()) return;
        if (TimelineController.instance != null &&
            TimelineController.instance.playableDirector.time > 0)
        {
            return;       
        }
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
    sign,
    tree,
    search,

}