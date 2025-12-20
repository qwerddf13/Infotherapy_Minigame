using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    // 1. 단일 프리팹 대신 배열을 사용하여 여러 물고기를 담습니다.
    public GameObject[] fishPrefabs; 
    
    public float spawnInterval = 1.5f;
    public float minY = -4.0f;
    public float maxY = -1.0f;
    public float screenLimitX = 12.0f;

    void Start()
    {
        StartCoroutine(SpawnFishRoutine());
    }

    IEnumerator SpawnFishRoutine()
    {
        while (true)
        {
            // 2. 등록된 물고기 프리팹 중 하나를 랜덤하게 선택합니다.
            int fishIndex = Random.Range(0, fishPrefabs.Length);
            GameObject selectedFish = fishPrefabs[fishIndex];

            // 방향 결정 로직 (기존과 동일)
            int side = Random.Range(0, 2);
            float spawnX = (side == 0) ? -screenLimitX : screenLimitX;
            Vector2 direction = (side == 0) ? Vector2.right : Vector2.left;
            float targetX = (side == 0) ? screenLimitX : -screenLimitX;

            float randomY = Random.Range(minY, maxY);
            
            // 3. 선택된 랜덤 물고기를 생성합니다.
            GameObject fish = Instantiate(selectedFish, new Vector3(spawnX, randomY, 0), Quaternion.identity);
            
            fish.GetComponent<FishMovement>().Setup(direction, targetX);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}