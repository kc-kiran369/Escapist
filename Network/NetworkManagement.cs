using UnityEngine;
using Unity.Netcode;

public class NetworkManagement : MonoBehaviour
{
    public void StartAsHost()
    {
        if (NetworkManager.Singleton.StartHost())
        {

        }
    }
    public void StartAsClient()
    {
        if (NetworkManager.Singleton.StartClient())
        {

        }
    }
}
