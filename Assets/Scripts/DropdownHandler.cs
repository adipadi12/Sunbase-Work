using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DropdownHandler : MonoBehaviour
{
    public Dropdown dropdown;
    public List<ClientData> allClients;
    public GameObject clientListContent; // Reference to the content area of the client list
    public GameObject clientPrefab; // Prefab for individual client UI element

    private void Start()
    {
        // Attach a listener to the dropdown
        dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown); });

        // Initialize allClients with example data
        InitializeClientData();

        // Update the client list UI initially with all clients
        UpdateClientListUI(allClients);
    }

    // Method to initialize example client data
    private void InitializeClientData()
    {
        // Initialize allClients with example data
        allClients = new List<ClientData>();
        allClients.Add(new ClientData("Client 1", 100, "Address 1"));
        allClients.Add(new ClientData("Client 2", 200, "Address 2"));
        allClients.Add(new ClientData("Client 3", 150, "Address 3"));
        // Add more clients as needed
    }

    // Method to handle dropdown value changes and update filtered clients
    void DropdownValueChanged(Dropdown dropdown)
    {
        // Get the selected filter option
        string filterOption = dropdown.options[dropdown.value].text;

        // Filter clients based on the selected option
        List<ClientData> filteredClients = FilterClients(filterOption);

        // Update the client list UI with filtered clients
        UpdateClientListUI(filteredClients);
    }

    // Method to filter clients based on the selected option
    private List<ClientData> FilterClients(string filterOption)
    {
        // Perform filtering based on the selected option
        List<ClientData> filteredClients = new List<ClientData>();

        foreach (ClientData client in allClients)
        {
            if (filterOption == "All clients" || (filterOption == "Managers only" && client.isManager) || (filterOption == "Non-managers" && !client.isManager))
            {
                filteredClients.Add(client);
            }
        }

        return filteredClients;
    }

    // Method to update the client list UI with filtered clients
    private void UpdateClientListUI(List<ClientData> clients)
    {
        // Clear existing client list UI elements
        foreach (Transform child in clientListContent.transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate UI elements for filtered clients
        foreach (ClientData client in clients)
        {
            GameObject clientUI = Instantiate(clientPrefab, clientListContent.transform);
            Text nameLabel = clientUI.transform.Find("NameLabel").GetComponent<Text>();
            Text pointsLabel = clientUI.transform.Find("PointsLabel").GetComponent<Text>();
            nameLabel.text = client.name;
            pointsLabel.text = "Points: " + client.points.ToString();
        }
    }
}

// Example class to represent a client
[System.Serializable]
public class ClientData
{
    public string name;
    public int points;
    public string address;
    public bool isManager;

    public ClientData(string name, int points, string address)
    {
        this.name = name;
        this.points = points;
        this.address = address;
    }
}
