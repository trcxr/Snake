using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public GameObject sectionPrefab;
    public GameObject snakeBody;

    private List<Vector3> currentPos;

    private FoodSpawner foodSpawner;
    private Vector3 moveStep;
    private Bounds levelBounds;
    private float time;

    private bool actionPending = false;

    // Start is called before the first frame update
    void Start()
    {
        foodSpawner = GameObject.Find("FoodSpawner").GetComponent<FoodSpawner>();

        levelBounds = GameObject.Find("Floor").gameObject.GetComponent<MeshRenderer>().bounds;
        Debug.Log(levelBounds);
        moveStep = Vector3.left;
        currentPos = new List<Vector3>();
        currentPos.Add(transform.position);

        foreach (Transform child in snakeBody.transform)
        {
            currentPos.Add(child.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.Instance.gameOver)
        {
            return;
        }

        time += Time.unscaledDeltaTime;

        if (time >= 0.1f)
        {
            time = 0f;

            for (int i = currentPos.Count - 1; i > 0; i--)
            {
                currentPos[i] = currentPos[i - 1];
            }

            currentPos[0] += moveStep;

            transform.position = currentPos[0];
            for (int i = 0; i < currentPos.Count - 1; i++)
            {
                snakeBody.transform.GetChild(i).position = currentPos[i + 1];
                if (currentPos[0] == currentPos[i + 1])
                {
                    Manager.Instance.gameOver = true;
                }
            }

            if (currentPos[0].x >= levelBounds.extents.x || currentPos[0].x <= -levelBounds.extents.x ||
                currentPos[0].z >= levelBounds.extents.z || currentPos[0].z <= -levelBounds.extents.z)
            {
                Manager.Instance.gameOver = true;
            }

            if (currentPos[0] == foodSpawner.GetCurrentFoodItem().transform.position)
            {
                // Increase score
                Manager.Instance.UpdateScore(foodSpawner.GetCurrentFoodScriptableObject());

                // Delete Food
                foodSpawner.DestroyAndSpawn();

                GameObject newChild = Instantiate(sectionPrefab, snakeBody.transform);
                newChild.transform.position = currentPos[currentPos.Count - 1];
                currentPos.Add(newChild.transform.position);
            }
            actionPending = false;
        }

        if (!actionPending && moveStep != Vector3.back && Input.GetKeyDown(KeyCode.W))
        {
            moveStep = Vector3.forward;
            actionPending = true;
            transform.localRotation = Quaternion.Euler(0, 90, 0);
        }

        if (!actionPending && moveStep != Vector3.right && Input.GetKeyDown(KeyCode.A))
        {
            moveStep = Vector3.left;
            actionPending = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (!actionPending && moveStep != Vector3.forward && Input.GetKeyDown(KeyCode.S))
        {
            moveStep = Vector3.back;
            actionPending = true;
            transform.localRotation = Quaternion.Euler(0, -90, 0);
        }

        if (!actionPending && moveStep != Vector3.left && Input.GetKeyDown(KeyCode.D))
        {
            moveStep = Vector3.right;
            actionPending = true;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
