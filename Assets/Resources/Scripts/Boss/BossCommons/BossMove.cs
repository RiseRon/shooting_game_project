using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
public class BossMove : MonoBehaviour
{
    public float moveSpeed; // 이동 스피드
    public float moveRange; // 이동 범위
    private Vector2 direction; // 이동 방향

    void Start()
    {
        direction = Vector2.up.normalized;
    }

    void Update()
    {
        if (transform.position.y >= moveRange) // 위쪽 이동 범위를 넘었는지 체크
        {
            direction = Vector2.down.normalized; // 아래쪽 방향으로 전환
        }
        else if (transform.position.y <= -moveRange) // 아래쪽 이동 범위를 넘었는지 체크
        {
            direction = Vector2.up.normalized; // 위쪽 방향으로 전환
        }
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
