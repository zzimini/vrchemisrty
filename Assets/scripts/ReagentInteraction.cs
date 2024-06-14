using UnityEngine;
using System.Collections;

public class ReagentInteraction : MonoBehaviour
{
    public string reagentInfo;
    private bool isUpdatingBeaker = false;

    void OnTriggerEnter(Collider other)
    {
        BeakerInteraction beaker = other.GetComponent<BeakerInteraction>();
        if (beaker != null && !isUpdatingBeaker)
        {
            StartCoroutine(UpdateBeaker(beaker));
            isUpdatingBeaker = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isUpdatingBeaker)
        {
            StopAllCoroutines();
            isUpdatingBeaker = false;
        }
    }

    IEnumerator UpdateBeaker(BeakerInteraction beaker)
    {
        while (true)
        {
            beaker.AddReagent(reagentInfo);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
