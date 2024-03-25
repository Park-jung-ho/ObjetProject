using System.Collections;
using UnityEngine;

public class DropItem3D : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GoDestroy());
    }
    IEnumerator GoDestroy()
    {
        Debug.Log("Destory");
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
