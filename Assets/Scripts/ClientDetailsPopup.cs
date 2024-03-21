using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClientDetailsPopup : MonoBehaviour
{
    public TextMeshPro nameLabel;
    public TextMeshPro pointsLabel;
    public TextMeshPro addressLabel;

    public void ShowClientDetails(string name, string points, string address)
    {
        nameLabel.text = "Name: " + name;
        pointsLabel.text = "Points: " + points;
        addressLabel.text = "Address: " + address;

        gameObject.SetActive(true); // Show the popup window
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false); // Hide the popup window
    }
}
