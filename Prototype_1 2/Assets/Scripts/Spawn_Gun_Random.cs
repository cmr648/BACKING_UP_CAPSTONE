using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Gun_Random : MonoBehaviour
{
    public Transform[] Gun_Spawn_Points;

    public float Time_In_Between;

    public GameObject[] Gun;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn_New_Gun");
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn_New_Gun()
    {
        while (true)
        {
          GameObject New_Weapon = Instantiate(Gun[Random.Range(0,Gun.Length)], Gun_Spawn_Points[Random.Range(0, Gun_Spawn_Points.Length - 1)].position, Quaternion.identity);

            New_Weapon.transform.position = new Vector3(New_Weapon.transform.position.x, New_Weapon.transform.position.y, 0);

            yield return new WaitForSeconds(Time_In_Between);
        }
    }
}



