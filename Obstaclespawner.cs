using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // ������ ��ֹ� ������
    public float spawnRangeX = 5f; // ��ֹ��� ������ X �� ����
    public float spawnPosZOffset = 20f; // ��ֹ��� ������ Z �� ��ġ �ʱ� ������
    public float spawnInterval = 1f; // ��ֹ� ���� �ֱ� (�� ����)
    public int obstacleCount = 2; // ���ÿ� ������ ��ֹ��� ����

    private GameObject player; // �÷��̾� ������Ʈ�� ������ ����
    private float lastSpawnedPlayerZ; // ���������� ��ֹ��� ������ �÷��̾��� Z �� ��ġ

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // "Player" �±׸� ���� ������Ʈ�� ã�Ƽ� �Ҵ�
        lastSpawnedPlayerZ = player.transform.position.z - spawnPosZOffset; // �ʱ�ȭ �� �÷��̾��� ��ġ���� �����¸�ŭ �� ���� �������� ����
        InvokeRepeating("CheckAndSpawnObstacles", spawnInterval, spawnInterval);
    }

    void CheckAndSpawnObstacles()
    {
        if (player == null)
        {
            Debug.LogWarning("Player not found!");
            return;
        }

        float playerZ = player.transform.position.z;

        // �÷��̾ ���� �Ÿ� �̻� �̵��� ��쿡�� ��ֹ��� ����
        if (playerZ > lastSpawnedPlayerZ + spawnPosZOffset)
        {
            // ���ÿ� ���� ���� ��ֹ� ����
            for (int i = 0; i < obstacleCount; i++)
            {
                // ��ֹ��� ������ X �� ��ġ ���
                float randomX = Random.Range(-spawnRangeX, spawnRangeX);
                Vector3 spawnPosition = new Vector3(randomX, 0.5f, playerZ + spawnPosZOffset);

                // ��ֹ� ����
                GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

                if (newObstacle == null)
                {
                    Debug.LogWarning("Failed to instantiate obstacle prefab!");
                    continue;
                }

                // ������ ��ֹ��� Z �� ��ġ ����
                lastSpawnedPlayerZ = playerZ;
            }
        }

    }
}
   