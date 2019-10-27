using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizardUnit : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        maxHp = hp;
        attack = 1;
        range = 3;
        speed = 0.75f;
        team = Random.Range(3, 4);

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
}

