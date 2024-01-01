using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] int maxPoints;

    int curPoints;
    public int CurPoints { get { return curPoints; } }

    private void Start()
    {
        curPoints = maxPoints;
    }

    public void IncrementScore(int incrementTheScore)
    {
        curPoints += incrementTheScore;
    }
}
