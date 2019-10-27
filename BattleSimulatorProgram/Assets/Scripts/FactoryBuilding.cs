using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryBuilding : Building
{
    [SerializeField] GameObject[] options = new GameObject[3];
    [SerializeField] protected int spawnType;
    [SerializeField] protected int spawnCost;

    private ResourceBuilding resourceBuilding;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        maxHp = hp;
        type = "Factory Building";
        spawnType = Random.Range(0, 2);
        spawnCost = 50;
        team = Random.Range(1, 3);

        GetComponent<MeshRenderer>().material = mat[team - 1];
        switch (team)
        {
            case 1:
                gameObject.tag = "Team 1";
                break;
            case 2:
                gameObject.tag = "Team 2";
                break;
        }
        healthBar = GetComponentsInChildren<Image>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        DeathCheck();
        SpawnUnit();
    }

    private void SpawnUnit()
    {       
        GameObject[] objects = (GameObject[])Object.FindObjectsOfType(typeof(GameObject));
        foreach (GameObject node in objects)
        {
            resourceBuilding = node.GetComponent<ResourceBuilding>();
            if (resourceBuilding != null && resourceBuilding.Team == this.team)
            {
                if (resourceBuilding.Generated >= spawnCost)
                {
                    GameObject spawnedUnit = Instantiate(options[spawnType]);
                    Debug.Log("Unit's Team Before: " + spawnedUnit.GetComponent<Unit>().Team);
                    spawnedUnit.GetComponent<Unit>().Team = this.team;
                    Debug.Log("Building's Team: " + this.team);
                    Debug.Log("Unit's Team After: " + spawnedUnit.GetComponent<Unit>().Team);
                    spawnedUnit.GetComponent<Unit>().transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
                    
                    resourceBuilding.Generated -= spawnCost;
                }
            }
        }        
    }
    protected void DeathCheck()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
