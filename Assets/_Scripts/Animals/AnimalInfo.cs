using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalInfo : MonoBehaviour
{
    public int AnimalIndex = 0;
    public int PointsWhenAnnihilated = 1;
    public float AnimalMass = 1f;
    
    private Rigidbody2D _rigidbody2D;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.mass = AnimalMass;
    }
}
