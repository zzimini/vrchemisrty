using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject infoCanvas;
    public TMP_Text infoText;

    void Start()
    {
        infoCanvas.SetActive(false);
    }

    public void ShowInfo(string info)
    {
        Debug.Log("Showing info: " + info);
        infoText.text = info;
        infoCanvas.SetActive(true);
    }

    public void HideInfo()
    {
        infoCanvas.SetActive(false);
    }
}
