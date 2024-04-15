using TMPro;
using UnityEngine;
public class ItemPickUp3D : MonoBehaviour
{
    public TextMeshProUGUI pressText;
    public Item3D item;
    public bool isPress = false;
    void Start()
    {
        pressText.GetComponentInChildren<TextMeshProUGUI>();
        pressText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPress) pressText.gameObject.SetActive(true);
        else pressText.gameObject.SetActive(false);
    }
}
