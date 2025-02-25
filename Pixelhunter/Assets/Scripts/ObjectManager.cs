using UnityEngine;
using TMPro;

public class ObjectManager : MonoBehaviour
{
    public string objectName;
    public GameObject objectNameText;

    private void OnMouseDown()
    {
        objectName = gameObject.name;
        GameObject.FindFirstObjectByType<GameManager>().ObjectClicked();
        Destroy(gameObject);
        Destroy(objectNameText);
    }
}
