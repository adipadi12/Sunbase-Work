using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClientFilter : MonoBehaviour
{
    public Dropdown dropdown;
    public GameObject clientListContent; // Reference to the content area of the client list
    public GameObject clientPrefab; // Prefab for individual client UI element
    public Text popupNameText;
    public Text popupPointsText;
    public Text popupAddressText;

    private List<Client> allClients = new List<Client>();
    private List<Client> filteredClients = new List<Client>();

    // Example class to represent a client
    public class Client
    {
        public string name;
        public int points;
        public string address;
    }

    // Method to initialize the dropdown options and set up filtering
    void Start()
    {
        dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown); });
        // Fetch data from API and populate allClients list
        // Example:
        // allClients = FetchClientsFromAPI();
        // For demonstration purposes, let's populate some example data:
        for (int i = 0; i < 10; i++)
        {
            Client client = new Client();
            client.name = "Client " + i;
            client.points = Random.Range(0, 100);
            client.address = "Address " + i;
            allClients.Add(client);
        }
        FilterClients();
    }

    // Method to handle dropdown value changes and update filtered clients
    void DropdownValueChanged(Dropdown dropdown)
    {
        FilterClients();
    }

    // Method to filter clients based on dropdown selection
    void FilterClients()
    {
        filteredClients.Clear();
        switch (dropdown.value)
        {
            case 0: // All clients
                filteredClients.AddRange(allClients);
                break;
            case 1: // Managers only (example filter)
                filteredClients.AddRange(allClients.FindAll(client => client.points > 50));
                break;
            case 2: // Non-managers (example filter)
                filteredClients.AddRange(allClients.FindAll(client => client.points <= 50));
                break;
        }
        UpdateClientListUI();
    }

    // Method to update the client list UI based on filtered clients
    void UpdateClientListUI()
    {
        // Clear existing client list UI elements
        foreach (Transform child in clientListContent.transform)
        {
            Destroy(child.gameObject);
        }
        // Instantiate UI elements for filtered clients
        foreach (Client client in filteredClients)
        {
            GameObject clientUI = Instantiate(clientPrefab, clientListContent.transform);
            Text nameLabel = clientUI.transform.Find("NameLabel").GetComponent<Text>();
            Text pointsLabel = clientUI.transform.Find("PointsLabel").GetComponent<Text>();
            nameLabel.text = client.name;
            pointsLabel.text = "Points: " + client.points.ToString();
            // Add click event listener to display client details popup
            Button button = clientUI.GetComponent<Button>();
            button.onClick.AddListener(delegate { DisplayClientDetails(client); });
        }
    }

    // Method to display client details popup
    void DisplayClientDetails(Client client)
    {
        popupNameText.text = "Name: " + client.name;
        popupPointsText.text = "Points: " + client.points.ToString();
        popupAddressText.text = "Address: " + client.address;
        // Show popup window
        // Example:
        // popupWindow.SetActive(true);
    }
}
