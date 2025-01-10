using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchVirtualCam : MonoBehaviour
{
    [SerializeField]private List<CinemachineVirtualCamera> Cams;

    public void SwitchCam(int _index)
    {
        if (_index >= Cams.Count) return;

        for (int i = 0; i < Cams.Count; i++)
        {
            Cams[i].gameObject.SetActive(false);
        }
        Cams[_index].gameObject.SetActive(true);
    }
    private void Awake()
    {
        SwitchCam(0);
    }
}
