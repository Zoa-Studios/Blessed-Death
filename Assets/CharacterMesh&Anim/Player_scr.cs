using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_scr : MonoBehaviour
{
    public Joystick Player_Joystick;
    public Joystick Aim_Joystick;

    public Animator AnimController;

    public float Velocity_Multyplier ;
    private bool Is_Aiming, Is_Moving;
    private WeaponAttachment_src WAWeaponInHand;

       //public Transform THitPoint;
    private GameObject GOPlayer;
    private LineRenderer LRBulletTrajectory;
    private float FNextShoot;
    private Rigidbody PlayerRB;
    private float NextFire;
   

    // Start is called before the first frame update
    void Start()
    {
       // Player_Joystick = GameObject.FindGameObjectsWithTag("Move_Joy");
        AnimController = GetComponent<Animator>();
        PlayerRB = GetComponent<Rigidbody>();
        WAWeaponInHand = GetComponent<WeaponAttachment_src>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
        
        PlayerRB.velocity = new Vector3(Player_Joystick.Horizontal*Velocity_Multyplier,
                                        PlayerRB.velocity.y*0,
                                        Player_Joystick.Vertical * Velocity_Multyplier);

        if(Input.GetKey("w"))
        {
            PlayerRB.velocity = new Vector3(10,0,0);
        }
        if(Aim_Joystick.Horizontal != 0 || Aim_Joystick.Vertical != 0)
            {
                Is_Aiming = true;
                AnimController.SetBool("Is_Aiming", true);
            }
            else
            {
                Is_Aiming = false;
                AnimController.SetBool("Is_Aiming", false);
            }

        if(PlayerRB.velocity.x!=0 || PlayerRB.velocity.z !=0)
            {
                AnimController.SetBool("IsMoving", true); 
            }
            else
            {
                AnimController.SetBool("IsMoving", false); 
            }

        if(Player_Joystick.Horizontal!=0 || Player_Joystick.Vertical !=0 || Aim_Joystick.Vertical!=0 || Aim_Joystick.Horizontal!=0)
        {

            _SetPlayerRotation();
        }

        if ((Aim_Joystick.Horizontal > 0.5f || Aim_Joystick.Vertical > 0.5f || Aim_Joystick.Horizontal < -0.5f || Aim_Joystick.Vertical < -0.5f)&& Time.time > NextFire)
        { 
            NextFire = Time.time + 1f;
        _PlayerShoot();
        }
        

            
    }

    void _PlayerShoot()
    {
        Debug.Log("FIre");
        
       LRBulletTrajectory = GetComponent<LineRenderer>();
       // Vector3 V3ShootOrigin = new Vector3(0.0f,0.0f,0.0f);
       /* V3ShootOrigin.x = PlayerRB.transform.position.x;
        V3ShootOrigin.y = PlayerRB.transform.position.y;
        V3ShootOrigin.z = PlayerRB.transform.position.z;*/
       Vector3 V3ShootOrigin =  WAWeaponInHand.Socket.transform.position;
        
        
        
        RaycastHit RCHObjectHited;
       LRBulletTrajectory.SetPosition ( 0,V3ShootOrigin);
        if(Physics.Raycast( V3ShootOrigin, PlayerRB.transform.forward, out RCHObjectHited, 500.0f))
        {
            LRBulletTrajectory.SetPosition(1,RCHObjectHited.point);
        }

        LRBulletTrajectory.enabled = true;

      if(RCHObjectHited.rigidbody != null)
       RCHObjectHited.rigidbody.AddForce(PlayerRB.transform.forward*2000.0f);
        
    }

  void _SetPlayerRotation()
  {
      if(!Is_Aiming)
        {
           // transform.rotation = Quaternion.LookRotation(PlayerRB.velocity);
            //transform.Translate(PlayerRB.velocity*Velocity_Multyplier*Time.deltaTime, Space.World);
           transform.eulerAngles = new Vector3( 0, Mathf.Atan2( Player_Joystick.Horizontal, Player_Joystick.Vertical) * 180 / Mathf.PI, 0 ); 
        }
        else
        {
           transform.eulerAngles = new Vector3( 0, Mathf.Atan2( Aim_Joystick.Horizontal, Aim_Joystick.Vertical) * 180 / Mathf.PI, 0 );
           // transform.Translate(PlayerRB.velocity*Fmul*Time.deltaTime, Space.World);
        }
  }

}


