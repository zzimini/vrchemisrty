using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScaleManager : MonoBehaviour
{
    public TMP_Text weightText; // ���� ���Ը� ǥ���� TextMeshPro UI ���
    private float totalWeight = 0f; // ���￡ �ִ� ��� ������Ʈ�� �� ����
    private HashSet<Rigidbody> objectsOnScale = new HashSet<Rigidbody>(); // ���￡ �ִ� ������Ʈ�� ����

    void Start()
    {
        UpdateWeightDisplay(); // �ʱ� ���� ǥ�� ������Ʈ
    }

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null && !objectsOnScale.Contains(rb))
        {
            objectsOnScale.Add(rb);
            UpdateWeight(); // ���￡ ������Ʈ�� �߰��Ǹ� ���� ������Ʈ
        }
    }

    void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null && objectsOnScale.Contains(rb))
        {
            objectsOnScale.Remove(rb);
            UpdateWeight(); // ���￡�� ������Ʈ�� ���ŵǸ� ���� ������Ʈ
        }
    }

    void UpdateWeight()
    {
        totalWeight = 0;
        foreach (var rb in objectsOnScale)
        {
            totalWeight += rb.mass * 1000; // ų�α׷��� �׷����� ��ȯ�Ͽ� �� ���� ���
        }
        UpdateWeightDisplay();
    }

    void UpdateWeightDisplay()
    {
        weightText.text = totalWeight.ToString("F1") + " g"; // TextMeshPro UI ��ҿ� ���� ǥ��
    }

    public void AddWeight(float weight)
    {
        totalWeight += weight;
        UpdateWeightDisplay(); // �ܺο��� ȣ���Ͽ� ���Ը� �߰��� �� �ֵ��� ��
    }
}
