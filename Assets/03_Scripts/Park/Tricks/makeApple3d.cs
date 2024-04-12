using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class makeApple3d : MonoBehaviour
{
    public UnityEvent OnglitchEvent;
    public GameObject apple3d;
    
    public int appleCnt = 0;

    void Update()
    {
        transform.position = PlayerController2D.instance.transform.position;
        if (appleCnt == 9) OnglitchEvent.Invoke();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("apple"))
        {
            appleCnt++;
            
            other.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            
            
            StartCoroutine(setoffapple(other.gameObject));

            
        }
    }
    IEnumerator setoffapple(GameObject apple)
    {
        yield return new WaitForSeconds(0.15f);
        Vector3 newpos = new Vector3(apple.transform.position.x,apple.transform.position.y,0f);
        apple.SetActive(false);
        GameObject newapple = Instantiate(apple3d,apple.transform.parent);
        newapple.transform.position = newpos;
    }
}
