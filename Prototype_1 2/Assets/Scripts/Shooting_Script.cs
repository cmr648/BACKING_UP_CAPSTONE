using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Script : MonoBehaviour
{

    public KeyCode Shoot;
    public bool Holding_Gun;

    GameObject Current_Weapon;

    public GameObject Bullet;

    public float Bullet_Force;

    public float Amount_Of_Bulelts;

    public Multiplayer_Checker My_Multiplayer_Checker;

    // Start is called before the first frame update
    void Start()
    {
        My_Multiplayer_Checker = GetComponent<Multiplayer_Checker>();
    }

    // Update is called once per frame
    void Update()
    {

        Current_Weapon = GetComponent<Pickup_Weapon>().Weapon_Held;

        Holding_Gun = GetComponent<Pickup_Weapon>().Holding_Weapon; 

        if(Current_Weapon != null)
        {
            if (Holding_Gun == true)
            {
                if (My_Multiplayer_Checker.Player == 1)
                {
                    if (Input.GetKeyDown(Shoot) || Input.GetButtonDown("Player_1_Square"))
                    {
                        GameObject new_Bullet = Instantiate(Bullet, Current_Weapon.GetComponent<Bullet_Holder>().Bullet_Place.transform.position, Quaternion.identity);

                        new_Bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * Bullet_Force);

                        Amount_Of_Bulelts -= 1;
                    }

                }
                else
                {
                    if (Input.GetKeyDown(Shoot))
                    {
                        GameObject new_Bullet = Instantiate(Bullet, Current_Weapon.GetComponent<Bullet_Holder>().Bullet_Place.transform.position, Quaternion.identity);

                        new_Bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * Bullet_Force);

                        Amount_Of_Bulelts -= 1;
                    }
                }


            }
        }

        if(Current_Weapon!= null)
        {
            if (Amount_Of_Bulelts == 0)
            {
                Destroy(Current_Weapon.gameObject);
            }
        }



    }

    public void Shoot_Nqw()
    {
        if (Current_Weapon != null)
        {
            if (Holding_Gun == true)
            {
                    GameObject new_Bullet = Instantiate(Bullet, Current_Weapon.GetComponent<Bullet_Holder>().Bullet_Place.transform.position, Quaternion.identity);

                    new_Bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * Bullet_Force);

                    Amount_Of_Bulelts -= 1;

            }
        }
    }
}
