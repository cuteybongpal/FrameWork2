using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : ILogger
{
    public void Log(string message)
    {
        //todo : ���߿� FireBase �����̳� �񵿱� �Լ��� ���� �Ϸ���� �ɸ� �ð� Ȥ�� ����� GPU�Ǵ� CPU ��뷮�� �߰�.
        Debug.Log(message);
    }
    public void Error(string message)
    {
        //todo : FireBase ���� ���̺�� ���� �޼��� �ֱ�
        //todo : FireBase ���� ���̺��� ���� �޼��� �ֱ�
        Debug.Log(message);
    }
    
}
