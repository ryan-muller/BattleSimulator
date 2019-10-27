using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected int range;
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp;
    [SerializeField] protected int attack;
    [SerializeField] protected float speed;
    [SerializeField] protected int team;
    [SerializeField] protected Material[] mat;

    protected Image healthBar;

    public int Range { get => range;  }
    public int Hp { get => hp; set => hp = value; }
    public int MaxHp { get => maxHp; }
    public int Attack { get => attack; }
    public float Speed { get => speed; }
    public int Team { get => team; }


    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        DeathCheck();
        if (GetClosestUnit() != null)
        {
            if (((float)hp / maxHp) <= (0.25 * maxHp) / 1000)
            {
                transform.position = Vector3.MoveTowards(transform.position, GetClosestUnit().transform.position, -(speed / 2) * Time.deltaTime);
            }
            else if (!IsInRange(GetClosestUnit()))
            {
                transform.position = Vector3.MoveTowards(transform.position, GetClosestUnit().transform.position, speed * Time.deltaTime);
            }
            else if (team == 3)
            {
                GameObject[] team1 = GameObject.FindGameObjectsWithTag("Team 1");
                GameObject[] team2 = GameObject.FindGameObjectsWithTag("Team 2");
                GameObject[] nonWizard = team1.Concat(team2).ToArray();
                foreach (GameObject enemy in nonWizard)
                {
                    if (IsInRange(enemy))
                    {
                        AttackEnemy(enemy);
                    }
                }
            }
            else if (team != 3)
            {
                AttackEnemy(GetClosestUnit());
            }
        }
        healthBar.fillAmount = ((float)hp / maxHp);
    }

    protected bool IsInRange(GameObject Enemy)
    {
        if (Vector3.Distance(transform.position, Enemy.transform.position) <= range)
        {
            return true;
        }
        else return false;
    }

    protected GameObject GetClosestUnit()
    {
        GameObject unit = null;
        GameObject[] units = null;
        GameObject[] team1 = null;
        GameObject[] team2 = null;
        GameObject[] team3 = null;

        switch (team)
        {
            case 1:
                team2 = GameObject.FindGameObjectsWithTag("Team 2");
                team3 = GameObject.FindGameObjectsWithTag("Team 3");
                units = team2.Concat(team3).ToArray();
                break;
            case 2:
                team1 = GameObject.FindGameObjectsWithTag("Team 1");
                team3 = GameObject.FindGameObjectsWithTag("Team 3");
                units = team1.Concat(team3).ToArray();
                break;
            case 3:
                team1 = GameObject.FindGameObjectsWithTag("Team 1");
                team2 = GameObject.FindGameObjectsWithTag("Team 2");
                units = team1.Concat(team2).ToArray();
                break;
        }
        float distance = 9999;
        foreach(GameObject temp in units)
        {
            float tempDist = Vector3.Distance(transform.position, temp.transform.position);
            if (tempDist <= distance)
            {
                distance = tempDist;
                unit = temp;
            }
        }
        return unit;       
    }

    protected void AttackEnemy(GameObject enemy)
    {
            enemy.GetComponent<Unit>().Hp -= this.attack;
    }

    protected void DeathCheck()
    {    
        if (hp <= 0)
        {
            Destroy(this.gameObject);    
        }
    }
}
