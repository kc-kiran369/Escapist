using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    GameObject Bullet;
    public void Fire()
    {
        GameObject temp = Instantiate(Bullet, transform.position, Quaternion.identity);
        temp.GetComponent<Rigidbody>().AddForce(transform.forward * 50, ForceMode.Impulse);
    }
}