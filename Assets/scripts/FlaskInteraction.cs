using UnityEngine;
using TMPro;

public class FlaskInteraction : MonoBehaviour
{
    public TMP_Text flaskInfoText;
    public MeshRenderer liquidRenderer;
    public Material newLiquidMaterial; // 변경할 Material
    private float totalWeight = 100.0f; // 기본 플라스크 무게 (그램 단위)
    private string flaskInfo = "Flask";
    private int beakerCount = 0; // 플라스크에 들어온 비커의 개수

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
                float addedWeight = beaker.GetTotalWeight(); // 비커의 총 무게 가져오기
                UpdateFlaskWeight(addedWeight); // 플라스크 무게 업데이트
                Destroy(other.gameObject); // 비커 제거
                beakerCount++; // 비커 개수 증가
                UpdateFlaskInfo();
                CheckBeakerCount(); // 비커 개수 체크
            }
        }
    }

    void UpdateFlaskWeight(float addedWeight)
    {
        totalWeight += addedWeight;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = totalWeight / 1000.0f; // 킬로그램 단위로 변환하여 추가
    }

    void UpdateFlaskInfo()
    {
        flaskInfoText.text = $"{flaskInfo} {totalWeight}g";
    }

    void CheckBeakerCount()
    {
        if (beakerCount >= 2)
        {
            Invoke("ChangeLiquidMaterial", 2.0f); // 2초 뒤에 ChangeLiquidMaterial 호출
        }
    }

    void ChangeLiquidMaterial()
    {
        if (liquidRenderer != null)
        {
            Material[] materials = liquidRenderer.materials;
            materials[0] = newLiquidMaterial; // Element 0의 Material 변경
            liquidRenderer.materials = materials;
            Debug.Log("Liquid material changed to Element 1");
        }
    }
}
