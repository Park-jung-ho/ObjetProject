using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckZone3D : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            StartCoroutine(checkApple(other));
        }
    }
    IEnumerator checkApple(Collider collision)
    {
        Box3D box3d = collision.GetComponent<Box3D>();
        yield return new WaitForSeconds(1f);
        if (box3d.appleCount == 3)
        {
            foreach (GameObject obj in box3d.collidedObjects)
            {
                Destroy(obj);
            }
            box3d.appleCount = 0;
        }
        else
        {
            Debug.Log("No");
        }
    }
}