using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_SRC : MonoBehaviour
{
    public float FireRate;
    public float Dmg;
    public int Ammunition;
    public GameObject Weapon_Mesh;
    public GameObject LeftHand;
    public GameObject RightHand;

    public Weapon_SRC(float FireRate, float Dmg, int Ammunition, GameObject Weapon_Mesh)
    {
        this.FireRate = FireRate;
        this.Dmg = Dmg;
        this.Ammunition = Ammunition;
        this.Weapon_Mesh = Weapon_Mesh;
    }

    public void _Fire()
    {
        Debug.Log("Fire");
    }
    


  
}
