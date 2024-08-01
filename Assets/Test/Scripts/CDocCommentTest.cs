using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// 1��¥�� ���� �ּ�
/// ���� �ּ��� �������� : �±װ� ���� ���ڴ� �Ϲ� �ּ��� ���� �ƹ� ȿ���� ����.
/// <summary>
/// �Ʒ� ���� ��� (class, field, property, method ��)�� ���� �Ϲ� ����
/// </summary>


public class DocCommentTestClass
{
    /// <summary>
    /// �ǹ� ���� <seealso cref="int"/> ����
    /// </summary>
    public int fieldA;

    /// <summary>
    /// �ǹ� ���� �޼ҵ�
    /// </summary>
    /// <param name="param">�ǹ� ���� �Ķ����</param>
    public void SomeMethod(string param)
    {

    }

    /// <summary>
    /// �ǹ� ���� �޼ҵ�
    /// </summary>
    /// <returns>�ǹ� ���� ��ȯ��</returns>
    public int SomeReturnableMethod()
    {
        return 0;
    }
}

/**
 * <summary>
 * ������ ����
 * 1��° ��
 * 2��° ��
 * 3��° ��
 * </summary>
 */
public class CDocCommentTest : MonoBehaviour
{
    #region public ����
    /// <summary>
    /// �ʿ��� ��쿡�� ���� �Ҵ��ϼ���. �ƴϸ� 0
    /// </summary>
    [Tooltip("�ʿ��� ��쿡�� ���� �Ҵ��ϼ���. �ƴϸ� 0")]
    public int fieldA;

    [Range(0, 1)]
    public float fieldB;

    public string fieldC;
    #endregion

    void Start()
    {
        DocCommentTestClass classA = new DocCommentTestClass();
        print(classA.fieldA);

        fieldA = 1;

        //fieldC = Extentions.IntValueToString(fieldA);
        fieldC = fieldA.IntValueToString();
        // ���� �Ķ���� �� �Ķ���� ������ ��� ���� Ư�� �Ķ���Ϳ� ���� �����ϰ� ���� ���, (�Ķ���� �� : ��) ���·� �Լ� ȣ�� ����
        fieldC = fieldA.IntValueToString(postfix: "cm");

        string jsonData = new MyData().ToJson();
    }
}

[System.Serializable]
public class MyData
{
    public int level;
    public int stage;
    public int @class;
    // todo : ���� ��� : ����.
    // Todo : ���� ��� : ����.
    // tOdO : ���� ��� : ����.
}

public static class Extentions
{
    /// <summary>
    /// Ȯ�� �޼��� : ù��° �Ķ���͸� .�����ڸ� ���ؼ� ���� �� �� �ִ� �޼���
    /// <br/>
    /// ���� ���� : ������ <see langword="static"/> �޼��忩�� �ϰ�, <see langword="static"/> Ŭ������ ������� ��
    /// </summary>
    /// <param name="param"></param>
    /// <param name="postfix">default �Ķ���� �Ҵ� : �޼��� ȣ�� �� �Ķ���� ���� �Է����� �ʾƵ� �⺻���� ���޵ȴ�.</param>
    /// <returns></returns>
    public static string IntValueToString(this int param, string prefix = "", string postfix = "")
    {
        return $"{prefix}{param.ToString()}{postfix}";
    }

    public static string ToJson(this MyData data)
    {
        // TODO : �̰� ���߿� ������ �������� List�� �ٲ��ּ���.
        return JsonUtility.ToJson(data);
    }
}