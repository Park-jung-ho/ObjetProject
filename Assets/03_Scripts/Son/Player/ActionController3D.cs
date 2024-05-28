using System;
using UnityEngine;
using UnityEngine.UI;

public class ActionController3D : MonoBehaviour
{
    public enum ItemType
    {
        Null,
        Apple,
        Box
    }
    public ItemType holdItem;
    [SerializeField]
    float range; // 습득거리
    bool pickupActivated = false; //습득가능 여부
    RaycastHit hitinfo; //충돌체 정보 저장
    [SerializeField]
    LayerMask layerMask;
    public OnItem3D onItem3D;
    public Image cusor;
    public Sprite[] cusorImages;
    void Start()
    {
        cusor.sprite = cusorImages[0];
        holdItem = ItemType.Null;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward));
        CheckItem();
        TryAction();
    }
    void TryAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckItem();
            CanPickUp();
        }
    }
    void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitinfo.transform != null && hitinfo.transform.gameObject.layer == LayerMask.NameToLayer("Item"))
            {
                string typename = hitinfo.transform.GetComponent<ItemPickUp3D>().item.itemType.ToString();
                onItem3D.ItemChange(typename);
                if (hitinfo.transform.tag == "Apple") Destroy(hitinfo.transform.gameObject);
                if (hitinfo.transform.tag == "Box") hitinfo.transform.gameObject.SetActive(false);
            }
            if (hitinfo.transform != null && hitinfo.transform.gameObject.layer == LayerMask.NameToLayer("NPC") && !GetComponentInParent<PlayerController3D>().isTalk)
            {
                Cursor.visible = true;
                if (hitinfo.transform.tag == "NPC") hitinfo.transform.gameObject.GetComponent<NPC>().Interact();
                GetComponentInParent<PlayerController3D>().isTalk = true;
                Debug.Log("Hello");
                cusor.gameObject.SetActive(false);
                Cursor.SetCursor(cusorImages[1].texture, Vector2.zero, CursorMode.Auto);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitinfo, range, layerMask))
        {
            if (hitinfo.transform.tag == "Item" || hitinfo.transform.gameObject.layer == LayerMask.NameToLayer("Item"))
            {
                cusor.sprite = cusorImages[1];
            }
            if (hitinfo.transform.gameObject.layer == LayerMask.NameToLayer("NPC"))
            {
                cusor.sprite = cusorImages[2];
            }
            pickupActivated = true;
        }
        else
        {
            cusor.sprite = cusorImages[0];
            pickupActivated = false;
        }
    }
}
