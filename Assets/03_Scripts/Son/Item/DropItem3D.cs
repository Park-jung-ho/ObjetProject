using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class DropItem3D : MonoBehaviour
{
    void Start()
    {

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground") StartCoroutine(GoDestroy());
    }

    IEnumerator GoDestroy()
    {
        Debug.Log("Destory");
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
