using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScaleManager : MonoBehaviour
{
    public TMP_Text weightText; // 저울 무게를 표시할 TextMeshPro UI 요소
    private float totalWeight = 0f; // 저울에 있는 모든 오브젝트의 총 무게
    private HashSet<Rigidbody> objectsOnScale = new HashSet<Rigidbody>(); // 저울에 있는 오브젝트의 집합

    void Start()
    {
        UpdateWeightDisplay(); // 초기 무게 표시 업데이트
    }

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null && !objectsOnScale.Contains(rb))
        {
            objectsOnScale.Add(rb);
            UpdateWeight(); // 저울에 오브젝트가 추가되면 무게 업데이트
        }
    }

    void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null && objectsOnScale.Contains(rb))
        {
            objectsOnScale.Remove(rb);
            UpdateWeight(); // 저울에서 오브젝트가 제거되면 무게 업데이트
        }
    }

    void UpdateWeight()
    {
        totalWeight = 0;
        foreach (var rb in objectsOnScale)
        {
            totalWeight += rb.mass * 1000; // 킬로그램을 그램으로 변환하여 총 무게 계산
        }
        UpdateWeightDisplay();
    }

    void UpdateWeightDisplay()
    {
        weightText.text = totalWeight.ToString("F1") + " g"; // TextMeshPro UI 요소에 무게 표시
    }

    public void AddWeight(float weight)
    {
        totalWeight += weight;
        UpdateWeightDisplay(); // 외부에서 호출하여 무게를 추가할 수 있도록 함
    }
}
