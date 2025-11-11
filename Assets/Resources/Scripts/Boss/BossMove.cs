using System.Collections.Concurrent;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
public class BossMove : MonoBehaviour
{
    private string bossSelect; // 씬 이름(스테이지) 확인 용도
    private float moveSpeed; // 이동 스피드
    private float moveRange; // 이동 범위
    private int direction = 1; // 이동 방향
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // 현재 씬 불러오기
        bossSelect = currentScene.name; // 현재 씬에서 씬 이름(스테이지) 가져오기
        switch (bossSelect) // 현재 씬 이름(스테이지)에 따라서 이동 범위 + 스피드 초기화
        {
            case "Stage1":
                Stage1();
                break;
            case "Stage2":
                Stage2();
                break;
            case "Stage3":
                Stage3();
                break;
            case "Stage4":
                Stage4();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= moveRange) // 위쪽 이동 범위를 넘었는지 체크
        {
            direction = -1; // 방향을 아래로 전환
        }
        else if (transform.position.y <= -moveRange) // 아래쪽 이동 범위를 넘었는지 체크
        {
            direction = 1; // 방향을 위로 전환
        }
        transform.position += Vector3.up * moveSpeed * direction * Time.deltaTime;
    }
    // 스테이지에 따른 초기화
    private void Stage1()
    {
        moveSpeed = 80;
        moveRange = 100;
    }
    private void Stage2()
    {
        moveSpeed = 0;
        moveRange = 0;
    }
    private void Stage3()
    {
        moveSpeed = 0;
        moveRange = 0;
    }
    private void Stage4()
    {
        moveSpeed = 0;
        moveRange = 0;
    }
}
