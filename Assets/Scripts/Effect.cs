using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particals = null;
    public GameObject bladePosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cuttable" || other.gameObject.tag == "ScoreTag")
        {
            particals.transform.position = bladePosition.transform.position;
            particals.Play();
        }
    }
}
