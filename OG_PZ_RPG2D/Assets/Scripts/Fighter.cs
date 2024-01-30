using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;
    //niesmiertelnosc latency
    public float immuneTime = 1.0f;
    public float lastImmune;

}
