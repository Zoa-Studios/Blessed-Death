using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttachment_src : MonoBehaviour
{

   public GameObject WeaponSocket = null;
    private Vector3 SoketLocation = new Vector3(0.2f,-0.03f,0.02f);
   public GameObject Parent = null;
    private Vector3 SocketRotation = new Vector3(180f,0,0);
    

    public GameObject Socket;
    
    // Start is called before the first frame update
    void Start()
    {
        if (WeaponSocket != null)
        {
            Socket = Instantiate (WeaponSocket, SoketLocation,Quaternion.identity) as GameObject;
      
        }
        
    }

    // Update is called once per frame
    void Update()
    {
      
        
        
           Socket.transform.parent = Parent.transform;
        
           Socket.transform.localPosition = SoketLocation;
            Socket.transform.localEulerAngles = SocketRotation;

            
    }
     void OnCollisionEnter(Collision Obj)
     {
         if (Obj.gameObject.tag == "Weapon")
         {
             Debug.Log("Colliding");
         }
     }

   
}
