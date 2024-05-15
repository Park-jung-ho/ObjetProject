using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bullet;
    public int bulletCount;
    public bool AutoShoot;
    public float coolTime;
    public float curTime;
    public Stack<GameObject> bullets;


    
    void Awake()
    {
        bullets = new Stack<GameObject>();
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject newBullet = Instantiate(bullet,transform);
            bullets.Push(newBullet);
        }    
    }
    void Update()
    {
        curTime += Time.deltaTime;
        if (AutoShoot && coolTime <= curTime && bullets.Count > 0)
        {
            curTime = 0f;
            
            float rspd = Random.Range(5f,10f);
            ShootToPlayer(rspd);
            
        }
    }

    [Button]
    public void ShootToPlayer(float speed)
    {
        GameObject newBullet = bullets.Pop();
        newBullet.transform.parent = transform.parent;
        Bullet bulletInfo = newBullet.GetComponent<Bullet>();
        newBullet.transform.position = MakeNewPos();
        bulletInfo.bulletController = this;
        bulletInfo.speed = speed;
        bulletInfo.pos = (PlayerController2D.instance.transform.position-newBullet.transform.position).normalized;
        newBullet.SetActive(true);
    }

    public void pushStack(GameObject Obj)
    {
        bullets.Push(Obj);
        Obj.transform.parent = transform;
        Obj.SetActive(false);
    }

    private Vector2 MakeNewPos()
    {
        Vector2 newPos = Vector2.zero;
        float min = 0f;
        float max = 1f;

        int randint = Random.Range(0,4);
        switch (randint)
        {
            case 0:
                newPos = new Vector2(max,Random.Range(min, max));
                break;
            case 1:
                newPos = new Vector2(min,Random.Range(min, max));
                break;
            case 2:
                newPos = new Vector2(Random.Range(min, max),max);
                break;
            case 3:
                newPos = new Vector2(Random.Range(min, max),min);
                break;
        }
        newPos = Camera.main.ViewportToWorldPoint(newPos);
        return newPos;
    }
}
