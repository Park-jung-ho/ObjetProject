using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box3D : MonoBehaviour
{
    public int appleCount = 0;
    [SerializeField]
    GameObject appleObj;
    [SerializeField]
    GameObject spawnpoint;
    public List<GameObject> collidedObjects = new List<GameObject>();
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            if (!collidedObjects.Contains(other.gameObject))
            {
                collidedObjects.Add(other.gameObject);
            }
            appleCount++;
            Debug.Log(appleCount);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Apple") appleCount--;
    }
    void OnEnable()
    {
        if (appleCount > 0)
        {
            int count = appleCount;
            appleCount = 0;
            for (int i = 0; i < count; i++)
            {
                Instantiate(appleObj, spawnpoint.transform.position, Quaternion.identity);
            }
        }

    }
    void OnDisable()
    {
        foreach (GameObject obj in collidedObjects)
        {
            Destroy(obj);
        }
    }
}
