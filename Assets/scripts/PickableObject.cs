using UnityEngine;
using TMPro;

public class PickableObject : MonoBehaviour
{
    public string info;
    public TMP_Text infoText; // Canvas에 표시할 TextMeshPro UI 요소
    public float weight; // 오브젝트의 무게

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
