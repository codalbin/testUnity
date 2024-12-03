using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public float forceMultiplier = 10f; // Multiplieur pour ajuster la force appliqu�e

    private Rigidbody rb;

    public GameObject golfFlag;  // R�f�rence � l'objet golf_flag
    private Renderer golfFlagRenderer;

    void Start()
    {
        // Obtenir le Rigidbody de l'objet
        rb = GetComponent<Rigidbody>();

        // S'assurer qu'on a une r�f�rence � l'objet golf_flag et obtenir son Renderer
        if (golfFlag != null)
        {
            golfFlagRenderer = golfFlag.GetComponent<Renderer>();
        }
        else
        {
            Debug.LogError("golfFlag n'est pas assign� dans l'inspecteur.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Golf collision enemy");

            // Calculer la force de la collision
            Vector3 collisionForce = collision.impulse / Time.fixedDeltaTime;

            // Multiplier uniquement les axes X et Z par le multiplicateur
            Vector3 adjustedForce = new Vector3(
                collisionForce.x * forceMultiplier, // Multiplier l'axe X
                0,               // Laisser l'axe Y inchang�
                collisionForce.z * forceMultiplier // Multiplier l'axe Z
            );

            // Appliquer la force ajust�e
            rb.AddForce(adjustedForce, ForceMode.Impulse);
        }

        if (collision.gameObject.name == "hole")
        {
            // V�rifier si le Renderer de golf_flag existe
            if (golfFlagRenderer != null)
            {
                // Changer la couleur de l'objet "golf_flag" en vert
                golfFlagRenderer.material.color = Color.green;
            }
            else
            {
                Debug.LogError("Le Renderer de golfFlag est introuvable.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "hole")
        {
            // V�rifier si le Renderer de golf_flag existe
            if (golfFlagRenderer != null)
            {
                // Changer la couleur de l'objet "golf_flag" en vert
                golfFlagRenderer.material.color = Color.green;
            }
            else
            {
                Debug.LogError("Le Renderer de golfFlag est introuvable.");
            }
        }

        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Golf trigger enemy");

            // Calculer la force de la collision
            Vector3 relativePosition = other.transform.position - transform.position ;

            // Multiplier uniquement les axes X et Z par le multiplicateur
            Vector3 adjustedForce = new Vector3(
                relativePosition.x * forceMultiplier, // Multiplier l'axe X
                0,               // Laisser l'axe Y inchang�
                relativePosition.z * forceMultiplier // Multiplier l'axe Z
            );

            // Appliquer la force ajust�e
            rb.AddForce(adjustedForce, ForceMode.Impulse);
        }
    }
}
