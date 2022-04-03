using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    string lockName;
    int[] values;
    GameObject gameObject;
    public Lock(string lockName, int[] values, GameObject gameObject)
    {
        this.lockName = lockName;
        this.values = values;
        this.gameObject = gameObject;
    }
}
