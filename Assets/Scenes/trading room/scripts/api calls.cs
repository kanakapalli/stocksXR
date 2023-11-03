using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class APIClientForUI : MonoBehaviour
{


    private string url = "https://reqres.in/api/users";
    public TextMeshProUGUI sampleText;

    void Start()
    {
        StartCoroutine(GetRequest(url));
    }


    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            if(webRequest.result == UnityWebRequest.Result.Success)
            {
                string response = webRequest.downloadHandler.text;
                UserResponse userResponse = JsonUtility.FromJson<UserResponse>(response);
                Debug.Log("GET: Received: " + response);

                // Now userResponse object contains the deserialized data, you can access its properties
                Debug.Log("Page: " + userResponse.page);
                Debug.Log("Per Page: " + userResponse.per_page);
                Debug.Log("Total: " + userResponse.total);
                Debug.Log("Total Pages: " + userResponse.total_pages);
                Debug.Log("Support URL: " + userResponse.support.url);
                Debug.Log("Support Text: " + userResponse.support.text);

                foreach (var user in userResponse.data)
                {
                    Debug.Log("User ID: " + user.id);
                    Debug.Log("User Email: " + user.email);
                    Debug.Log("User First Name: " + user.first_name);
                    Debug.Log("User Last Name: " + user.last_name);
                    Debug.Log("User Avatar: " + user.avatar);
                }
                sampleText.text = userResponse.data[0].first_name;
            }

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }
}
//IEnumerator GetUserResponse()
//{
//    using (UnityWebRequest webRequest = UnityWebRequest.Get(baseUrl))
//    {
//        yield return webRequest.SendWebRequest();

//        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
//        {
//            Debug.LogError("GET: Error: " + webRequest.error);
//        }
//        else
//        {
//            string response = webRequest.downloadHandler.text;
//            UserResponse userResponse = JsonUtility.FromJson<UserResponse>(response);
//            Debug.Log("GET: Received: " + response);

//            // Now userResponse object contains the deserialized data, you can access its properties
//            Debug.Log("Page: " + userResponse.page);
//            Debug.Log("Per Page: " + userResponse.per_page);
//            Debug.Log("Total: " + userResponse.total);
//            Debug.Log("Total Pages: " + userResponse.total_pages);
//            Debug.Log("Support URL: " + userResponse.support.url);
//            Debug.Log("Support Text: " + userResponse.support.text);

//            foreach (var user in userResponse.data)
//            {
//                Debug.Log("User ID: " + user.id);
//                Debug.Log("User Email: " + user.email);
//                Debug.Log("User First Name: " + user.first_name);
//                Debug.Log("User Last Name: " + user.last_name);
//                Debug.Log("User Avatar: " + user.avatar);
//            }
//        }
//    }
//}




// model for user 
[System.Serializable]
public class User
{
    public int id;
    public string email;
    public string first_name;
    public string last_name;
    public string avatar;
}

[System.Serializable]
public class Support
{
    public string url;
    public string text;
}

[System.Serializable]
public class UserResponse
{
    public int page;
    public int per_page;
    public int total;
    public int total_pages;
    public User[] data;
    public Support support;
}
