using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bRooms;
    public GameObject[] tRooms;
    public GameObject[] lRooms;
    public GameObject[] rRooms;
    public GameObject[] ltRoom;
    public GameObject[] lbRoom;
    public GameObject[] rtRoom;
    public GameObject[] rbRoom;

    public GameObject topend;
    public GameObject bottomend;
    public GameObject leftend;
    public GameObject rightend;



    //spawnpoints
    public GameObject center;
    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;
    //number of spawnpoints spawned
    public int spawnnum = 0;

    //current active spawnpoint
    public int nextspawn = 1;

    //number of spawnedrooms
    public int roomnum = 0;
    public int roommax = 10;
}
