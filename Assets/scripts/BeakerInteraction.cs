using UnityEngine;
using TMPro;

public class BeakerInteraction : MonoBehaviour
{
    public TMP_Text infoText;
    public string beakerInfo = "Water {0}ml";
    public float baseWeight = 5.0f; // �⺻ ����Ŀ ���� (�׷� ����)
    public float waterWeight = 200.0f; // ���� ���� ���� (�׷� ����)
    public float reagentIncrement = 0.1f; // �þ� �߰� �� �����ϴ� ���� (�׷� ����)

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
        scaleManager.AddWeight(reagentIncrement); // ������ ���Ե� ������Ŵ
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
        rb.mass = (baseWeight + waterWeight) / 1000.0f; // ų�α׷� ������ ��ȯ
    }

    public float GetTotalWeight()
    {
        return baseWeight + waterWeight;
    }
}
