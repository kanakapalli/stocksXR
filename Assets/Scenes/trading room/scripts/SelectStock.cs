using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStock : MonoBehaviour
{
    public GameObject prefab; // Reference to your prefab

    // Method to create a new game object from a prefab using an int parameter
    public void CreateGameObjectFromPrefab(int index)
    {
        if (prefab != null)
        {
            // Instantiate a new game object from the prefab
            GameObject newGameObject = Instantiate(prefab);

            // Set the new game object's name (optional)
            newGameObject.name = $"GameObjectFromPrefab {index}";

            // Set the new game object's position using the int parameter
            newGameObject.transform.position = new Vector3(-1.984f, 1.036f, -0.379f);
        }
        else
        {
            Debug.LogError("Prefab is not assigned.");
        }
    }
}
