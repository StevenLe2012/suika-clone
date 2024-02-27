using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFruitController : MonoBehaviour
{
    public static ThrowFruitController Instance;
    
    public GameObject CurrentFruit { get; set; }
    [SerializeField] private Transform fruitTransform;
    [SerializeField] private Transform parentAfterThrow;
    [SerializeField] private AnimalSelector selector;
    
    private PlayerController _playerController;
    private Rigidbody2D _rigidbody2D;
    private CircleCollider2D _circleCollider;
    
    public Bounds Bounds { get; private set; }
    
    private const float EXTRA_WIDTH = 0.02f;

    public bool CanThrow { get; set; } = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        SpawnFruit(selector.PickRandomAnimalForThrow());
    }

    private void Update()
    {
        if (UserInput.IsThrowPressed && CanThrow)
        {
            SpriteIndex index = CurrentFruit.GetComponent<SpriteIndex>();
            Quaternion rotation = CurrentFruit.transform.rotation;
            
            GameObject go = Instantiate(AnimalSelector.Instance.Animals[index.Index], CurrentFruit.transform.position, rotation);
            go.transform.SetParent(parentAfterThrow);
            
            Destroy(CurrentFruit);

            CanThrow = false;
        }
    }
    
    public void SpawnFruit(GameObject fruit)
    {
        GameObject newFruit = Instantiate(fruit, fruitTransform);
        CurrentFruit = newFruit;
        _circleCollider = CurrentFruit.GetComponent<CircleCollider2D>();
        Bounds = _circleCollider.bounds;
        
        _playerController.ChangeBoundry(EXTRA_WIDTH);
    }
}
