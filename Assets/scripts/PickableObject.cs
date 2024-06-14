using UnityEngine;
using TMPro;

public class PickableObject : MonoBehaviour
{
    public string info;
    public TMP_Text infoText; // Canvas�� ǥ���� TextMeshPro UI ���
    public float weight; // ������Ʈ�� ����

    void OnMouseDown()
    {
        DisplayInfo();
    }

    public void DisplayInfo()
    {
        if (infoText != null)
        {
            infoText.text = info;
        }
    }

    public void UpdateInfo(string newInfo)
    {
        info = newInfo;
        DisplayInfo();
    }

    public float GetWeight()
    {
        return weight;
    }
}
