using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    int count = 0;
    float timer = 0;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsInRange(GetClosestUnit()))
        {
            transform.position = Vector3.MoveTowards(transform.position, GetClosestUnit().transform.position, speed * Time.deltaTime);
        }
        Debug.Log(count);
        count++;
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

        switch (team)
        {
            case 1:
                units = GameObject.FindGameObjectsWithTag("Team 2");
                break;
            case 2:
                units = GameObject.FindGameObjectsWithTag("Team 1");
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
        Debug.Log(unit);
        return unit;
        
    }
}
