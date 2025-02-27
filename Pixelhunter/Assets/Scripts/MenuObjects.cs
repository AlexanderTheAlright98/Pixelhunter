using UnityEngine;

public class MenuObjects : MonoBehaviour
{
    public ParticleSystem successParticle;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, 50 * Time.deltaTime);
    }
    private void OnMouseDown()
    {
        Destroy(Instantiate(successParticle, transform.position, successParticle.transform.rotation), 0.33f);
        Destroy(gameObject);
    }
}
