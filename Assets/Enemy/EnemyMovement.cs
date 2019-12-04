using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
        public GameObject Player;
        public float movementSpeed;
        void Update()
        {
            transform.LookAt(Player.transform);
            transform.position += transform.forward * movementSpeed * Time.deltaTime;

        }
}
