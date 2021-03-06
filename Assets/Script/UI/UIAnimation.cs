﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIAnimation : MonoBehaviour
{
    float StartTime;
    float time;

    float duration;
    float startDelay;
    Vector3 scaleTo;
    AnimationCurve animationCurve;
    TweenScale tween;

    void Awake()
    {
        setDisable();

        StartTime = Time.realtimeSinceStartup;

        duration = 0.2f; // 애니메이션의 길이입니다.(시간)
        startDelay = 0.1f; // 애니메이션 시작 전 딜레이입니다.
        scaleTo = new Vector3(1f, 1f, 1f); // 오브젝트의 최종 Scale 입니다.

        // 부풀었다가 줄어드는 효과를 위한 AnimationCurve 입니다.       
        animationCurve = new AnimationCurve(
        new Keyframe(0f, 0f, 0f, 1f), // 0%일때 0의 값에서 시작해서 
        new Keyframe(0.7f, 1.2f, 1.2f, 1f), // 애니메이션 시작후 70% 지점에서 1.2의 사이즈까지 커졌다가 
        new Keyframe(1f, 1f, 1f, 1f)); // 100%로 애니메이션이 끝날때는 1.0의 사이즈가 됩니다.
    }

    private void Update()
    {
        // TimeScale의 영향을 받지 않게 한다.
        time = Time.realtimeSinceStartup - StartTime;
        StartTime = Time.realtimeSinceStartup;
    }

    //SetActive(true) 호출 시 실행됩니다.
    void OnEnable()
    {
        //init();
        tween = TweenScale.Begin(gameObject, duration, scaleTo);
        tween.duration = duration;
        tween.delay = startDelay;
        tween.animationCurve = animationCurve;
        //open();
    }
    //SetActive(false) 호출 시 실행됩니다.
    void OnDisable()
    {
        close();
    }

    // 팝업 열기
    void open()
    {
        init();

    }

    // 초기화
    void init()
    {
        TweenScale tween = TweenScale.Begin(gameObject, duration, scaleTo);
        tween.duration = duration;
        tween.delay = startDelay;
        tween.animationCurve = animationCurve;
       
    }

    // 팝업 닫기
    public void close()
    {
        setDisable();
    }

    // 오브젝트 Disable
    void setDisable()
    {
		gameObject.transform.localScale = new Vector3(0, 0, 0);
        gameObject.SetActive(false);
    }
}
