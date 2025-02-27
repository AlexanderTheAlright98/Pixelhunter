using UnityEngine;
using TMPro;

public class ObjectManager : MonoBehaviour
{
    public string objectName;
    public GameObject objectNameText;
    public ParticleSystem successParticle;

    private void OnMouseDown()
    {
        objectName = gameObject.name;
        GameObject.FindFirstObjectByType<GameManager>().ObjectClicked();
        Destroy(Instantiate(successParticle, transform.position, successParticle.transform.rotation), 0.33f);
        Destroy(gameObject);
        Destroy(objectNameText);
    }
}
