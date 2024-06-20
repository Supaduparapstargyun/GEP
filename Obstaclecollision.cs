using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Player collided with obstacle!");
            // 여기에 게임 종료 로직 추가 가능
            // 예를 들어, 게임 종료 함수 호출 또는 게임 오브젝트 비활성화 등
        }
    }
}

