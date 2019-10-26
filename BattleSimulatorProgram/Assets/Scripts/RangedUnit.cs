using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangedUnit : Unit
{

    // Start is called before the first frame update
    void Start()
    {

        hp = 8;
        maxHp = hp;
        attack = 3;
        range = 2;
        speed = 0.5f;
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
    }
}

