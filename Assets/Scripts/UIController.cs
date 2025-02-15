using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniVRM10;

public class UIController : MonoBehaviour
{
    [SerializeField]SwitchVirtualCam switchVirtualCam;

    [SerializeField] List<Button> CamBtnList;
    [SerializeField] Button switchModeBtn;
    [SerializeField] TMP_InputField inputField;
    private TextMeshProUGUI switchModeBtnTxt;
    private bool isDesktopPetMode;
    [Header("ExpressionBtn")]
    [SerializeField]Button happyBtn;
    [SerializeField]Button angryBtn;
    [SerializeField]Button sadBtn;
    [SerializeField]Button surpriseBtn;

    void Start()
    {
        switchModeBtnTxt = switchModeBtn.GetComponentInChildren<TextMeshProUGUI>();

        SetCamBtn();
        switchModeBtn.onClick.AddListener(switchModeBtnFun);

        switchModeBtnFun();
        
        happyBtn.onClick.AddListener(() => EventManager.ExpressionChanged(ExpressionKey.Happy));
        angryBtn.onClick.AddListener(() => EventManager.ExpressionChanged(ExpressionKey.Angry));
        sadBtn.onClick.AddListener(() => EventManager.ExpressionChanged(ExpressionKey.Sad));
        surpriseBtn.onClick.AddListener(() => EventManager.ExpressionChanged(ExpressionKey.Surprised));
    }
    private void switchModeBtnFun()
    {
        isDesktopPetMode = !isDesktopPetMode;
        ChangeSwitchBtnTxt();
        SetPartUIActive();
        SwitchScreenMode.SwitchDesktopPetMode(isDesktopPetMode);
    }

    private void ChangeSwitchBtnTxt()
    {
        switchModeBtnTxt.text = isDesktopPetMode ? "DesktopPet" : "Fullscreen";
    }

    private void SetPartUIActive()
    {
        for (int i = 0; i < CamBtnList.Count; i++)
        {
            CamBtnList[i].gameObject.SetActive(!isDesktopPetMode);
        }
        inputField.gameObject.SetActive(!isDesktopPetMode);
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
