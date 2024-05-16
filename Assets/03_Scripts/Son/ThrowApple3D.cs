using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowApple3D : MonoBehaviour
{
    public float projectileSpeed = 10f; // 발사체의 속도

    private Transform player; // 플레이어를 나타내는 변수

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // "Player" 태그를 가진 오브젝트의 Transform을 가져옴
        if (player == null)
        {
            Debug.LogError("플레이어를 찾을 수 없습니다.");
        }
        else
        {
            // 플레이어 방향으로 발사체를 날아가도록 설정
            Vector3 direction = (player.position - transform.position).normalized; // 플레이어 방향 벡터
            GetComponent<Rigidbody>().velocity = direction * projectileSpeed; // 발사체에 속도를 부여하여 플레이어 방향으로 날아가도록 함
        }
    }
}
