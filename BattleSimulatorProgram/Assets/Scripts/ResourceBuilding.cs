using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBuilding : Building
{
    [SerializeField] private int remainingPool;
    [SerializeField] private int generated;
    [SerializeField] private int genRate;
    [SerializeField] private int genAmount;
    [SerializeField] private float timer;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        maxHp = hp;
        type = "Resource Building";
        remainingPool = 100;
        generated = 0;
        genRate = 1;
        genAmount = 5;
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

    // Update is called once per frame
    void Update()
    {
        int resourceTotal = GenerateResources();
        Text resourceBox = GameObject.Find("ResourceText").GetComponent<Text>();
        resourceBox.text = "Resources: " + resourceTotal;
    }

    protected int GenerateResources()
    {
        if (remainingPool >= genAmount)
        {
            timer += Time.deltaTime;
            if (timer >= genRate)
            {
                generated += genAmount;
                remainingPool -= genAmount;
            }
        }
        return generated;
    }
}
