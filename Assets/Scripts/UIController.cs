using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]SwitchVirtualCam switchVirtualCam;
    [SerializeField] List<Button> CamBtnList;


    void Start()
    {
        SetCamBtn();
    }

    
    private void SetCamBtn()
    {
        for (int i = 0; i < CamBtnList.Count; i++)
        {
            int j=i;
            CamBtnList[i].onClick.AddListener(() => switchVirtualCam.SwitchCam(j));
        }
    }
}
