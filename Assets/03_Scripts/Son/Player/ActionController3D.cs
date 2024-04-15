using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;

public class ActionController3D : MonoBehaviour
{
    [SerializeField]
    float range; // 습득거리

    bool pickupActivated = false; //습득가능 여부

    RaycastHit hitinfo; //충돌체 정보 저장

    [SerializeField]
    LayerMask layerMask;
    public OnItem3D onItem3D;

    void Start()
    {

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
        if (Input.GetMouseButton(0))
        {
            CheckItem();
            CanPickUp();
        }
    }
    void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitinfo.transform != null)
            {
                string typename = hitinfo.transform.GetComponent<ItemPickUp3D>().item.itemType.ToString();
                onItem3D.ItemChange(typename);
                if (hitinfo.transform.tag == "Apple") Destroy(hitinfo.transform.gameObject);
                if (hitinfo.transform.tag == "Box") hitinfo.transform.gameObject.SetActive(false);
            }
        }
    }
    void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitinfo, range, layerMask))
        {
            if (hitinfo.transform.tag == "Item" || hitinfo.transform.gameObject.layer == LayerMask.NameToLayer("Item"))
            {
                ItemInfoAppear();
            }
        }
        else
            InfoDisappear();
    }
    void ItemInfoAppear()
    {
        pickupActivated = true;
        hitinfo.transform.GetComponent<ItemPickUp3D>().isPress = true;
    }
    void InfoDisappear()
    {
        ItemPickUp3D[] rayitems = FindObjectsOfType<ItemPickUp3D>();
        for (int i = 0; i < rayitems.Length; i++)
        {
            rayitems[i].isPress = false;
        }
        pickupActivated = false;
    }
}
