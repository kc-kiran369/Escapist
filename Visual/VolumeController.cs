using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeController : MonoBehaviour
{
    [SerializeField] Volume volume;

    private void Awake()
    {
        volume = GetComponent<Volume>();
    }
    private void Foo()
    {
        //volume.profile.Has<Bloom>();
        //volume.profile.TryGet<Bloom>().
    }
}
