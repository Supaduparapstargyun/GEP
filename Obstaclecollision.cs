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
            // ���⿡ ���� ���� ���� �߰� ����
            // ���� ���, ���� ���� �Լ� ȣ�� �Ǵ� ���� ������Ʈ ��Ȱ��ȭ ��
        }
    }
}

