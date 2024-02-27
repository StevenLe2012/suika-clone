using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCombiner : MonoBehaviour
{
    private int _layerIndex;

    private AnimalInfo _info;
    
    private void Awake()
    {
        _info = GetComponent<AnimalInfo>();
        _layerIndex = gameObject.layer;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != _layerIndex) return;
        
        AnimalInfo collisionInfo = collision.gameObject.GetComponent<AnimalInfo>();
        if (collisionInfo == null) return;
        if (collisionInfo.AnimalIndex != _info.AnimalIndex) return;
        
        int thisID = _info.GetInstanceID();
        int otherID = collision.gameObject.GetInstanceID();

        
        if (thisID > otherID)
        {
            GameManager.Instance.IncreaseScore(_info.PointsWhenAnnihilated);
            // if last animal, destroy both
            if (_info.AnimalIndex == AnimalSelector.Instance.Animals.Length - 1)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            // else spawn in next animal in middle position
            else
            {
                Vector3 middlePosition = (transform.position + collision.transform.position) / 2f;
                GameObject newAnimal = Instantiate(SpawnCombinedAnimal(_info.AnimalIndex + 1), GameManager.Instance.transform);
                newAnimal.transform.position = middlePosition;

                ColliderInformer informer = newAnimal.GetComponent<ColliderInformer>();
                if (informer != null)
                {
                    informer.WasCombinedIn = true;
                }
                
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }

    private GameObject SpawnCombinedAnimal(int index)
    {
        GameObject newAnimal = AnimalSelector.Instance.Animals[index];
        return newAnimal;
    }
}
