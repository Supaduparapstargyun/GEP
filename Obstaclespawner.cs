using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // 생성할 장애물 프리팹
    public float spawnRangeX = 5f; // 장애물이 생성될 X 축 범위
    public float spawnPosZOffset = 20f; // 장애물이 생성될 Z 축 위치 초기 오프셋
    public float spawnInterval = 1f; // 장애물 생성 주기 (초 단위)
    public int obstacleCount = 2; // 동시에 생성할 장애물의 개수

    private GameObject player; // 플레이어 오브젝트를 참조할 변수
    private float lastSpawnedPlayerZ; // 마지막으로 장애물을 생성한 플레이어의 Z 축 위치

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // "Player" 태그를 가진 오브젝트를 찾아서 할당
        lastSpawnedPlayerZ = player.transform.position.z - spawnPosZOffset; // 초기화 시 플레이어의 위치에서 오프셋만큼 뺀 값을 기준으로 설정
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

        // 플레이어가 일정 거리 이상 이동한 경우에만 장애물을 생성
        if (playerZ > lastSpawnedPlayerZ + spawnPosZOffset)
        {
            // 동시에 여러 개의 장애물 생성
            for (int i = 0; i < obstacleCount; i++)
            {
                // 장애물이 생성될 X 축 위치 계산
                float randomX = Random.Range(-spawnRangeX, spawnRangeX);
                Vector3 spawnPosition = new Vector3(randomX, 0.5f, playerZ + spawnPosZOffset);

                // 장애물 생성
                GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

                if (newObstacle == null)
                {
                    Debug.LogWarning("Failed to instantiate obstacle prefab!");
                    continue;
                }

                // 생성된 장애물의 Z 축 위치 저장
                lastSpawnedPlayerZ = playerZ;
            }
        }

    }
}
   