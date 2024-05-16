using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AppleSpawner3D : MonoBehaviour
{
    public GameObject throwApple;
    [SerializeField]
    float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Throwing", waitTime);
    }
    void Update()
    {

    }
    void Throwing()
    {
        StartCoroutine(Throw());
    }
    IEnumerator Throw()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Instantiate(throwApple, this.transform.position, Quaternion.identity);
        }
    }
}
