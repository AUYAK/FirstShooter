using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {
    public Weapon weapon;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    public LayerMask mask;
     void Start()
    {
        if (cam == null)
        { Debug.LogError("No camera"); }
    }
     void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit _hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit,weapon.range, mask)){ Debug.Log("We did shot a " + _hit.collider.name); }
        }

    }
}
