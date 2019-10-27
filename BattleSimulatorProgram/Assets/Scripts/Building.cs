using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp;
    [SerializeField] protected int team;
    [SerializeField] protected string type;
    [SerializeField] protected Material[] mat;

    protected Image healthBar;

    public int Hp { get => hp; set => hp = value; }
    public int MaxHp { get => maxHp; }
    public int Team { get => team; }
    public string Type { get => type; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
