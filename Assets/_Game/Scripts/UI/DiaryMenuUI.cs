using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryMenuUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI _menuNameTF;
    public string _diaryClassName;

    DiaryUIController _dairyUIController;

    public void SetupDiaryMenuData(string menuName, DiaryUIController diaryUIController)
    {
        _menuNameTF.text = _diaryClassName = menuName;
        _dairyUIController = diaryUIController;
    }
    public void RefreshArtworkList()
    {
        _dairyUIController.RefreshArtwork(_diaryClassName);
    }
}
