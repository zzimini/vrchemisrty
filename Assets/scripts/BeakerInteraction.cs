using UnityEngine;
using TMPro;

public class BeakerInteraction : MonoBehaviour
{
    public TMP_Text infoText;
    public string beakerInfo = "Water {0}ml";
    public float baseWeight = 5.0f; // 기본 비이커 무게 (그램 단위)
    public float waterWeight = 200.0f; // 현재 물의 무게 (그램 단위)
    public float reagentIncrement = 0.1f; // 시약 추가 시 증가하는 무게 (그램 단위)

    private Rigidbody rb;
    private ScaleManager scaleManager;
    private string currentInfo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scaleManager = FindObjectOfType<ScaleManager>();
        currentInfo = string.Format(beakerInfo, waterWeight);
        UpdateRigidbodyMass();
        UpdateBeakerInfo();
    }

    void OnMouseDown()
    {
        DisplayInfo();
    }

    public void AddReagent(string reagentInfo)
    {
        waterWeight += reagentIncrement;
        currentInfo = "Water + " + reagentInfo + " " + waterWeight + "ml";
        UpdateRigidbodyMass();
        UpdateBeakerInfo();
        scaleManager.AddWeight(reagentIncrement); // 저울의 무게도 증가시킴
    }

    void DisplayInfo()
    {
        if (infoText != null)
        {
            infoText.text = currentInfo;
        }
    }

    void UpdateBeakerInfo()
    {
        DisplayInfo();
    }

    void UpdateRigidbodyMass()
    {
        rb.mass = (baseWeight + waterWeight) / 1000.0f; // 킬로그램 단위로 변환
    }

    public float GetTotalWeight()
    {
        return baseWeight + waterWeight;
    }
}
