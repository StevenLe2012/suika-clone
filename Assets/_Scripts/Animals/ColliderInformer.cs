using UnityEngine;

public class ColliderInformer : MonoBehaviour
{
    public bool WasCombinedIn { get; set; }

    private bool _hasCollided;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!_hasCollided && !WasCombinedIn)
        {
            _hasCollided = true;
            DropAnimalController.Instance.CanThrow = true;
            DropAnimalController.Instance.SpawnFruit(AnimalSelector.Instance.NextAnimal);
            AnimalSelector.Instance.PickNextAnimal();
            Destroy(this);
        }
    }
}
