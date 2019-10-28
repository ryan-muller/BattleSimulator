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
    private Resources resources;
    // Start is called before the first frame update
    void Start()
    {
        hp = 500;
        maxHp = hp;
        type = "Factory Building";
        spawnType = Random.Range(0, 2);
        spawnCost = 30;
        team = Random.Range(1, 4);
        if (team == 3)
        {
            spawnType = 2;
        }

        GetComponent<MeshRenderer>().material = mat[team - 1];
        switch (team)
        {
            case 1:
                gameObject.tag = "Team 1";
                break;
            case 2:
                gameObject.tag = "Team 2";
                break;
            case 3:
                gameObject.tag = "Team 3";
                break;
        }
        healthBar = GetComponentsInChildren<Image>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = ((float)hp / maxHp);
        DeathCheck();
        if (Random.Range(0, 9) < 3)
        {

            GameObject[] objects = (GameObject[])Object.FindObjectsOfType(typeof(GameObject));
            foreach (GameObject node in objects)
            {
                resources = null;
                resources = node.GetComponent<Resources>();
                if (resources != null)
                {
                    break;
                }
            }
            Debug.Log(resources.TotalTeam1Out);
            

            foreach (GameObject node in objects)
            {
                resourceBuilding = node.GetComponent<ResourceBuilding>();
                if (resourceBuilding != null && resourceBuilding.Team == this.team)
                {
                    switch (resourceBuilding.Team)
                    {
                        case 1:
                            if (resources.TotalTeam1Out >= spawnCost)
                            {
                                SpawnUnit();
                                resourceBuilding.Generated -= spawnCost;
                                resources.TotalTeam1Out -= spawnCost;
                            }
                            break;
                        case 2:
                            if (resources.TotalTeam2Out >= spawnCost)
                            {
                                SpawnUnit();
                                resourceBuilding.Generated -= spawnCost;
                                resources.TotalTeam2Out -= spawnCost;
                            }
                            break;
                        case 3:
                            if (resources.TotalTeam3Out >= spawnCost)
                            {
                                SpawnUnit();
                                resourceBuilding.Generated -= spawnCost;
                                resources.TotalTeam3Out -= spawnCost;
                            }
                            break;
                    }
                }
            }
        }
    }

    private void SpawnUnit()
    {
        GameObject spawnedUnit = Instantiate(options[spawnType]);
        spawnedUnit.GetComponent<Unit>().Team = this.team;
        spawnedUnit.GetComponent<Unit>().transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);                                        
    }
    protected void DeathCheck()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
