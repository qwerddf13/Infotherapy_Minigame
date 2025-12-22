using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearLauncher : MonoBehaviour
{
    [Header("조준 설정")]
    public float angleOffset = -90f;

    [Header("발사 설정")]
    public float shootSpeed = 20f;
    public float returnSpeed = 15f;
    public float maxDistance = 10f;
    
    private Vector3 originLocalPos;
    private Vector3 targetWorldPos;
    private bool isShooting = false;
    private bool isReturning = false;

    void Start()
    {
        originLocalPos = transform.localPosition;
    }

    void Update()
    {
        if (!isShooting && !isReturning)
        {
            HandleAiming();
            if (Input.GetMouseButtonDown(0))
            {
                StartShoot();
            }
        }
        else
        {
            HandleMovement();
        }
    }

    void HandleAiming()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + angleOffset);
    }

    void StartShoot()
    {
        isShooting = true;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 dir = (mousePos - transform.position).normalized;
        targetWorldPos = transform.position + (dir * maxDistance);
    }

    void HandleMovement()
    {
        if (isShooting)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWorldPos, shootSpeed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, targetWorldPos) < 0.1f)
            {
                isShooting = false;
                isReturning = true;
            }
        }
        else if (isReturning)
        {
            // --- 추가된 로직: 보트를 바라보도록 회전 ---
            // 부모(보트)의 위치를 월드 좌표로 변환하여 방향을 구합니다.
            Vector3 worldOriginPos = transform.parent.TransformPoint(originLocalPos);
            Vector2 returnDir = new Vector2(worldOriginPos.x - transform.position.x, worldOriginPos.y - transform.position.y);
            float returnAngle = Mathf.Atan2(returnDir.y, returnDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, returnAngle + angleOffset);
            // ------------------------------------------

            // 원래 위치로 복귀
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, originLocalPos, returnSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.localPosition, originLocalPos) < 0.01f)
            {
                transform.localPosition = originLocalPos;
                isReturning = false;
                // 복귀 완료 후 다시 마우스를 조준하도록 각도 초기화는 Update의 HandleAiming에서 처리됨
            }
        }
    }
}