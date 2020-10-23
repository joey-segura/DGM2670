using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class StepSpawnBehaviour : MonoBehaviour
{

    public GameObject step_1, step_2;
    
    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(91f, 108f), 10F, Random.Range(43f, 55f));
        Vector3 randomPosition2 = new Vector3(Random.Range(92f, 108f), 10F, Random.Range(23f, 38f));

        Instantiate(step_1, randomPosition, Quaternion.identity);
        Instantiate(step_2, randomPosition2, Quaternion.identity);
    }
}
