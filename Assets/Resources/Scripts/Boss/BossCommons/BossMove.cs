using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
public class BossMove : MonoBehaviour
{
    private Dictionary<string, (float speed, float range)> bossMoveData;
    private string bossSelect; // 씬 이름(스테이지) 확인 용도
    private float moveSpeed; // 이동 스피드
    private float moveRange; // 이동 범위
    private Vector2 direction; // 이동 방향
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // 1. 초기 데이터 설정 (Awake에서 한 번만 설정)
        // 씬 이름(key)과 (속도, 범위)의 튜플(value)을 저장
        bossMoveData = new Dictionary<string, (float speed, float range)>
        {
            { "Stage1", (64f, 80f) }, // Stage1: 속도 64, 범위 80
            { "Stage2", (120f, 120f) }, // Stage2: 속도 120, 범위 120
            { "Stage3", (96f, 120f) }, // Stage2: 속도 120, 범위 120
            { "Stage4", (0f, 0f) }
        };
        direction = Vector2.up.normalized;
    }
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // 현재 씬 불러오기
        bossSelect = currentScene.name; // 현재 씬에서 씬 이름(스테이지) 가져오기
        if (bossMoveData.ContainsKey(bossSelect))
        {
            (moveSpeed, moveRange) = bossMoveData[bossSelect];
        }
    }

    // Update is called once per frame
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
