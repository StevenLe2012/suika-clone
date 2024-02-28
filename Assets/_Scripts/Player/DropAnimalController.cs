using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAnimalController : MonoBehaviour
{
    public static DropAnimalController Instance;
    
    public GameObject CurrentAnimal { get; set; }
    [SerializeField] private Transform animalTransform;
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
            AudioManager.Instance.PlayDropSFX();
            
            SpriteIndex index = CurrentAnimal.GetComponent<SpriteIndex>();
            Quaternion rotation = CurrentAnimal.transform.rotation;
            
            GameObject go = Instantiate(AnimalSelector.Instance.Animals[index.Index], CurrentAnimal.transform.position, rotation);
            go.transform.SetParent(parentAfterThrow);
            
            Destroy(CurrentAnimal);

            CanThrow = false;
        }
    }
    
    public void SpawnFruit(GameObject animal)
    {
        GameObject newFruit = Instantiate(animal, animalTransform);
        CurrentAnimal = newFruit;
        _circleCollider = CurrentAnimal.GetComponent<CircleCollider2D>();
        Bounds = _circleCollider.bounds;
        
        _playerController.ChangeBoundry(EXTRA_WIDTH);
    }
}
