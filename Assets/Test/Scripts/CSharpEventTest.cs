using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region C# �̺�Ʈ��?
/*

�� Ư¡

- �̺�Ʈ�� ������ Ŭ������ ȣ���� �� �ִ�.

- delegate �ʵ�� Interface���� ������ �� ������ event�� �����ϴ�.

- �̷� ������ Event�� �����ϴ� ������ Observer������ ������ ���ؼ� �����Ѵ�.
 
*/
#endregion

public delegate void SomeEvent(int a);

public class CSharpEventTest : MonoBehaviour
{
    #region public ����
    public event SomeEvent someEvent;
    public event Action<int, int> someAction;
    public event Func<int, int> someFunc;
    #endregion

    #region private ����
    #endregion

    void Start()
    {
        EventTestClass testClass = new EventTestClass();
        testClass.OnInit(this);

        someEvent?.Invoke(1);
    }
}

public class EventTestClass
{
    public void OnInit(CSharpEventTest tester)
    {
        tester.someEvent += (int a) => { new GameObject(a.ToString()); };
    }
}

public interface IDestroyable
{
    public event SomeEvent OnDestroy;
}

public class DestroyWhen10Sec : IDestroyable
{
    public event SomeEvent OnDestroy;

    // 10�� �Ŀ� �ı��Ǹ鼭 ȣ��� �Լ�
    void WhenDestroy()
    {
        // �ı��Ǵ� ������ ���� �Ŀ�
        OnDestroy?.Invoke(1);
    }
}