using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : ILogger
{
    public void Log(string message)
    {
        //todo : 나중에 FireBase 연동이나 비동기 함수의 실행 완료까지 걸린 시간 혹은 사용한 GPU또는 CPU 사용량을 추가.
        Debug.Log(message);
    }
    public void Error(string message)
    {
        //todo : FireBase 오류 테이블에 오류 메세지 넣기
        Debug.Log(message);
    }
    
}
