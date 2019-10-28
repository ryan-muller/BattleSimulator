using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    [SerializeField] GameObject[] options = new GameObject[5];
    [SerializeField] static int MIN_X = -20, MAX_X = 20, MIN_Z = -20, MAX_Z = 20, UNITS = 9, BUILDINGS = 6;
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < UNITS; i++)
        {
            CreateUnit();
        }
        for (int k = 0; k < BUILDINGS; k++)
        {
            CreateBuilding();
        }

    }

    private void CreateUnit()
    {
        GameObject unit = Instantiate(options[Random.Range(0, 3)]);
        unit.transform.position = new Vector3(Random.Range(MIN_X, MAX_X), 0, Random.Range(MIN_Z, MAX_Z));
    }

    private void CreateBuilding()
    {
        GameObject building = Instantiate(options[Random.Range(3, 5)]);
        building.transform.position = new Vector3(Random.Range(MIN_X, MAX_X), 0, Random.Range(MIN_Z, MAX_Z));
    }
    // Update is called once per frame
    void Update()
    {

    }
}
