using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Resources : MonoBehaviour
{
    private ResourceBuilding resourceBuilding;
    protected int totalTeam1 = 0, totalTeam2 = 0, totalTeam3 = 0;
    protected int totalTeam3Out=0;
    protected int totalTeam1Out=0;
    protected int totalTeam2Out=0;

    public int TotalTeam1Out { get => totalTeam1Out; set => totalTeam1Out = value; }
    public int TotalTeam2Out { get => totalTeam2Out; set => totalTeam2Out = value; }
    public int TotalTeam3Out { get => totalTeam3Out; set => totalTeam3Out = value; }

    // Start is called before the first frame update
    void Start()
    {
        totalTeam1 = 0;
        totalTeam2 = 0;
        totalTeam3 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        Text resourceBox;
        GameObject[] objects = (GameObject[])FindObjectsOfType(typeof(GameObject));
        foreach (GameObject node in objects)
        {
            resourceBuilding = node.GetComponent<ResourceBuilding>();
            
            if (resourceBuilding != null)
            {
                switch (resourceBuilding.Team)
                {
                    case 1:
                        totalTeam1 += resourceBuilding.Generated;
                        resourceBox = GameObject.Find("ResourceTeam1").GetComponent<Text>();
                        resourceBox.text = "Team 1's Resources: " + totalTeam1;
                        break;
                    case 2:
                        totalTeam2 += resourceBuilding.Generated;
                        resourceBox = GameObject.Find("ResourceTeam2").GetComponent<Text>();
                        resourceBox.text = "Team 2's Resources: " + totalTeam2;
                        break;
                    case 3:
                        totalTeam3 += resourceBuilding.Generated;
                        resourceBox = GameObject.Find("ResourceTeam3").GetComponent<Text>();
                        resourceBox.text = "Team 3's Resources: " + totalTeam3;
                        break;
                }               
            }
        }
        totalTeam1Out = totalTeam1;
        totalTeam2Out = totalTeam2;
        totalTeam3Out = totalTeam3;
        totalTeam1 = 0;
        totalTeam2 = 0;
        totalTeam3 = 0;

    }
}
