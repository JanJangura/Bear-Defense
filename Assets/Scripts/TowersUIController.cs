using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowersUIController : MonoBehaviour
{
    [SerializeField] private GameObject _towerInformationPanel;
    [SerializeField] private TMP_Text _towerName;
    [SerializeField] private TMP_Text _towerCost;
    [SerializeField] private TMP_Text _towerSpeed;
    [SerializeField] private TMP_Text _towerDescription;

    void Start()
    {
        HideTowerInformation();
    }

    public void ShowTowerInformation(Bear towerInformation)
    {
        _towerInformationPanel.SetActive(true);

        _towerName.text = towerInformation.Name;
        _towerCost.text = $"<b>Cost:</b> $ {towerInformation.Cost.ToString()}";
        _towerSpeed.text = $"<b>Speed:</b> {towerInformation.Speed}";
        _towerDescription.text = towerInformation.Description;
    }

    public void HideTowerInformation()
    {
        _towerName.text = "";
        _towerCost.text = "";
        _towerSpeed.text = "";
        _towerDescription.text = "";

        _towerInformationPanel.SetActive(false);
    }
}
