using DG.Tweening;
using UnityEngine;

public class GPUTest : MonoBehaviour
{
    public GameObject CapFrame;
    public GameObject CapBlades;
    public GameObject[] CoreCaps;

    public void MoveCapFrameUp(float value)
    {
        CapFrame.transform.DOMoveY(value, 5f);
        CapBlades.transform.DOMoveY(value, 5f);
    }

    public void MoveCoreCaps(float value)
    {
        foreach (var coreCap in CoreCaps) coreCap.transform.DOMoveY(value, 15f);
    }
}