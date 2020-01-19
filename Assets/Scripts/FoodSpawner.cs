using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public Food[] foods;

    private Bounds levelBounds;
    private bool foodSpawned;
    private GameObject currentFoodItem;
    private Food currentFoodObj;

    // Start is called before the first frame update
    void Start()
    {
        levelBounds = GameObject.Find("Floor").gameObject.GetComponent<MeshRenderer>().bounds;
    }

    // Update is called once per frame
    void Update()
    {
        if (!foodSpawned)
        {
            currentFoodObj = GetRandomFood();
            currentFoodItem = Instantiate(currentFoodObj.prefab, GetRandomLocation(), Quaternion.identity);

            Debug.Log(currentFoodItem.GetComponent<Renderer>().material.color);
            currentFoodItem.GetComponent<Renderer>().material.SetColor("_BaseColor", currentFoodObj.color);
            Debug.Log(currentFoodItem.GetComponent<Renderer>().material.color);

            foodSpawned = true;
        }
    }

    private Food GetRandomFood()
    {
        return foods[Random.Range(0, foods.Length)];
    }

    private Vector3 GetRandomLocation()
    {
        int x = Random.Range(-(int)levelBounds.extents.x + 3, (int)levelBounds.extents.x - 3);
        int z = Random.Range(-(int)levelBounds.extents.z + 3, (int)levelBounds.extents.z - 3);

        return new Vector3(x - 0.5f, 0.0f, z - 0.5f);
    }

    public GameObject GetCurrentFoodItem()
    {
        return currentFoodItem;
    }

    public Food GetCurrentFoodScriptableObject()
    {
        return currentFoodObj;
    }

    public void DestroyAndSpawn()
    {
        Destroy(currentFoodItem);
        foodSpawned = false;
    }
}
