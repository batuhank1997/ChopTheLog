using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Slice : MonoBehaviour
{
    public Material mat;
    public LayerMask mask;
    public float speed = 0.1f;

    private void Update()
    {
        
        if (true)
        {
            Collider[] cutObjects = Physics.OverlapBox(transform.position, new Vector3(1f, 0.1f, 0.1f), transform.rotation, mask);

            foreach (Collider obj in cutObjects)
            {
                if(obj.gameObject)
                {
                    
                    SlicedHull cuttedObject = Cut(obj.gameObject, mat);
                    GameObject upPart = cuttedObject.CreateUpperHull(obj.gameObject, mat);
                    GameObject downPart = cuttedObject.CreateLowerHull(obj.gameObject, mat);

                    AddComponents(upPart);
                    AddComponents(downPart);
                    Destroy(obj.gameObject);
                }
            }
        }
    }

    public SlicedHull Cut(GameObject obj, Material mat = null)
    {
        return obj.Slice(transform.position, transform.up, mat);
    }

    void AddComponents(GameObject obj)
    {
        if(obj.GetComponent<Rigidbody>() == null) 
        {
            Rigidbody rb = obj.AddComponent<Rigidbody>();
            obj.AddComponent<MeshCollider>().convex = true;
            obj.AddComponent<Rigidbody>();
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.AddExplosionForce(200, obj.transform.position, 50);
        }
        
    }
}