using UnityEngine;
using TMPro;

public class FlaskInteraction : MonoBehaviour
{
    public TMP_Text flaskInfoText;
    public MeshRenderer liquidRenderer;
    public Material newLiquidMaterial; // ������ Material
    private float totalWeight = 100.0f; // �⺻ �ö�ũ ���� (�׷� ����)
    private string flaskInfo = "Flask";
    private int beakerCount = 0; // �ö�ũ�� ���� ��Ŀ�� ����

    void Start()
    {
        UpdateFlaskInfo();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Beaker"))
        {
            BeakerInteraction beaker = other.GetComponent<BeakerInteraction>();
            if (beaker != null)
            {
                float addedWeight = beaker.GetTotalWeight(); // ��Ŀ�� �� ���� ��������
                UpdateFlaskWeight(addedWeight); // �ö�ũ ���� ������Ʈ
                Destroy(other.gameObject); // ��Ŀ ����
                beakerCount++; // ��Ŀ ���� ����
                UpdateFlaskInfo();
                CheckBeakerCount(); // ��Ŀ ���� üũ
            }
        }
    }

    void UpdateFlaskWeight(float addedWeight)
    {
        totalWeight += addedWeight;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = totalWeight / 1000.0f; // ų�α׷� ������ ��ȯ�Ͽ� �߰�
    }

    void UpdateFlaskInfo()
    {
        flaskInfoText.text = $"{flaskInfo} {totalWeight}g";
    }

    void CheckBeakerCount()
    {
        if (beakerCount >= 2)
        {
            Invoke("ChangeLiquidMaterial", 2.0f); // 2�� �ڿ� ChangeLiquidMaterial ȣ��
        }
    }

    void ChangeLiquidMaterial()
    {
        if (liquidRenderer != null)
        {
            Material[] materials = liquidRenderer.materials;
            materials[0] = newLiquidMaterial; // Element 0�� Material ����
            liquidRenderer.materials = materials;
            Debug.Log("Liquid material changed to Element 1");
        }
    }
}
