using UnityEngine;
using TMPro;

public class ObjectManager : MonoBehaviour
{
    public string objectName;
    public GameObject objectNameText;

    private void OnMouseDown()
    {
        GameObject.FindFirstObjectByType<ClickController>().misclicks = 0;
        objectName = gameObject.name;
        Destroy(gameObject);
        Destroy(objectNameText);
    }

}
