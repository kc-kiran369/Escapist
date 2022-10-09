using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform BulletSpawnPoint;
    public void Fire()
    {
        //TODO : SOUND / MUZZLE / RECOIL
        GameObject temp = Instantiate(Bullet, transform.position, Quaternion.identity);
        temp.GetComponent<Rigidbody>().AddForce(-transform.right * 50, ForceMode.Impulse);
    }

    public void OnDrawGizmos()
    {
        //Gizmos.DrawLine(transform.position, Quaternion.identity.eulerAngles * 10);
    }
}