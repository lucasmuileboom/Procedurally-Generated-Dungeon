using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class room : MonoBehaviour
{
    [SerializeField] private List<GameObject> doors = new List<GameObject>();
    private roomspawner _roomspawner;

    void Awake ()
    {
        _roomspawner = GameObject.Find("Main Camera").GetComponent<roomspawner>();
        _roomspawner.check += this.checkneighbours;
    }

    private void checkneighbours()
    {
        if (_roomspawner.Rooms(((int)transform.position.x / _roomspawner.Roomsize()) + _roomspawner.Mapsize() + 1, ((int)transform.position.y / _roomspawner.Roomsize()) + _roomspawner.Mapsize()) == null)
        {//check right
            closedoors(doors[4]);
            closedoors(doors[5]);
        }
        if (_roomspawner.Rooms(((int)transform.position.x / _roomspawner.Roomsize()) + _roomspawner.Mapsize() - 1, ((int)transform.position.y / _roomspawner.Roomsize()) + _roomspawner.Mapsize()) == null)
        {//check left
            closedoors(doors[0]);
            closedoors(doors[1]);
        }
        if (_roomspawner.Rooms(((int)transform.position.x / _roomspawner.Roomsize()) + _roomspawner.Mapsize(), ((int)transform.position.y / _roomspawner.Roomsize()) + _roomspawner.Mapsize() + 1) == null)
        {//check up
            closedoors(doors[2]);
            closedoors(doors[3]);
        }
        if (_roomspawner.Rooms(((int)transform.position.x / _roomspawner.Roomsize()) + _roomspawner.Mapsize(), ((int)transform.position.y / _roomspawner.Roomsize()) + _roomspawner.Mapsize() - 1) == null)
        {//check down
            closedoors(doors[6]);
            closedoors(doors[7]);
        }
    }
    private void closedoors(GameObject door)
    {
        door.SetActive(true);
    }
}
