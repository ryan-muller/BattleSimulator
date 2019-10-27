using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBuilding : Building
{
    [SerializeField] protected int remainingPool;
    [SerializeField] protected int generated;
    [SerializeField] protected int genRate;
    [SerializeField] protected int genAmount;
    [SerializeField] protected float timer;

    public int Generated { get => generated; set => generated = value; }


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
            case 3:
                gameObject.tag = "Team 3";
                break;
        }
        healthBar = GetComponentsInChildren<Image>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        DeathCheck();
        int resourceTotal = GenerateResources();
        Text resourceBox;
        switch (team)
        {
            case 1:
                resourceBox = GameObject.Find("ResourceTeam1").GetComponent<Text>();
                resourceBox.text = "Team 1's Resources: " + resourceTotal;
                break;
            case 2:
                resourceBox = GameObject.Find("ResourceTeam2").GetComponent<Text>();
                resourceBox.text = "Team 2's Resources: " + resourceTotal;
                break;
            case 3:
                resourceBox = GameObject.Find("ResourceTeam3").GetComponent<Text>();
                resourceBox.text = "Team 3's Resources: " + resourceTotal;
                break;
        }
        healthBar.fillAmount = ((float)hp / maxHp);
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
                timer = 0;
            }
        }
        return generated;
    }

    protected void DeathCheck()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
