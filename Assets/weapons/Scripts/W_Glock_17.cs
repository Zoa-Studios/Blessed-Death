using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_Glock_17 : Weapon_SRC
{
    public Transform THitPoint;
    private GameObject GOPlayer;
    private LineRenderer LRBulletTrajectory;
    private float FNextShoot;

   
     W_Glock_17(float FireRate, float Dmg, int Ammunition, GameObject Weapon_Mesh) : base(FireRate,Dmg,Ammunition,Weapon_Mesh)
    {
        FireRate = 1;
        Dmg = 10;
        Ammunition = 12;
        Weapon_Mesh = GameObject.Find("Assets/weapons/Glock_17");
    }

    void Start()
    {
        LRBulletTrajectory = GetComponent<LineRenderer>();
       

    }

    public void _WeaponFire()
    {
        Vector3 V3ShootOrigin = Weapon_Mesh.transform.position;
        RaycastHit RCHObjectHited;
        LRBulletTrajectory.SetPosition ( 0,THitPoint.position);
        if(Physics.Raycast ( V3ShootOrigin, Weapon_Mesh.transform.forward, out RCHObjectHited, 500.0f))
        {
            LRBulletTrajectory.SetPosition(1,RCHObjectHited.point);
        }

        LRBulletTrajectory.enabled = true;
    }
    
    

   

    
}
