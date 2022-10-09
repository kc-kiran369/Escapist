using UnityEngine;

class Bullet : MonoBehaviour
{
    void Start()
    {
        GameObject.Destroy(this.gameObject, 3.0f);
    }
}