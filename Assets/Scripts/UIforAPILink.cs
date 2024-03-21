using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIforAPILink : MonoBehaviour
{
    private APILink APILink;

    private void Start()
    {
        APILink = GetComponent<APILink>(); // Assuming APILink is attached to the same GameObject
        StartCoroutine(FetchDataAndUpdateUI());
    }

    private IEnumerator FetchDataAndUpdateUI()
    {
        // Call the FetchClientData method and provide a callback function
        yield return StartCoroutine(APILink.GetDataFromClient(OnClientDataReceived));
    }
    [System.Serializable]
    public class ClientData
    {
        public string name;
        public int points;
        public string address;
    }

    [System.Serializable]
    public class APIResponse
    {
        public List<ClientData> clients;
    }
    private void OnClientDataReceived(string jsonData)
    {
        // Parse the JSON data into a suitable data structure
        APIResponse apiResponse = JsonUtility.FromJson<APIResponse>(jsonData);

        if (apiResponse != null)
        {
            // Iterate over the list of clients and do something with the data
            foreach (ClientData client in apiResponse.clients)
            {
                Debug.Log("Client Name: " + client.name);
                Debug.Log("Points: " + client.points);
                Debug.Log("Address: " + client.address);
            }
        }
        else
        {
            Debug.LogError("Failed to parse API response!");
        }
    }
}
