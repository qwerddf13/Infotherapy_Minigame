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
            if (Input.GetMouseButtonDown(0)) StartShoot();
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

        if (FScoreManager.instance != null)
        {
            FScoreManager.instance.PlayShootSound();
        }
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
            Vector3 worldOriginPos = transform.parent.TransformPoint(originLocalPos);
            Vector2 returnDir = new Vector2(worldOriginPos.x - transform.position.x, worldOriginPos.y - transform.position.y);
            float returnAngle = Mathf.Atan2(returnDir.y, returnDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, returnAngle + angleOffset);

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, originLocalPos, returnSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.localPosition, originLocalPos) < 0.2f)
            {
                transform.localPosition = originLocalPos;
                isReturning = false;
                CollectFish();
            }
        }
    }

    void CollectFish()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Transform child = transform.GetChild(i);
            if (child.CompareTag("Fish"))
            {
                FishMovement fish = child.GetComponent<FishMovement>();
                if (fish != null && FScoreManager.instance != null)
                {
                    FScoreManager.instance.AddScore(fish.scoreValue);
                }
                Destroy(child.gameObject);
            }
        }
    }
}