using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {

    }

    //public Vector3 moveDirection = new Vector3(1, 0, 0); // Direction du mouvement
    //public float moveSpeed = 5f; // Vitesse du mouvement

    //void OnCollisionEnter(Collision collision)
    //{
    //    // Vérifie si l'objet qui entre en collision a le tag souhaité
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        // Applique un mouvement à cet objet
    //        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    //    }
    //}

    public float forceMultiplier = 10f; // Multiplieur pour ajuster la force appliquée

    private Rigidbody rb;

    public GameObject golfFlag;  // Référence à l'objet golf_flag
    private Renderer golfFlagRenderer;

    void Start()
    {
        // Obtenir le Rigidbody de l'objet
        rb = GetComponent<Rigidbody>();

        // S'assurer qu'on a une référence à l'objet golf_flag et obtenir son Renderer
        if (golfFlag != null)
        {
            golfFlagRenderer = golfFlag.GetComponent<Renderer>();
        }
        else
        {
            Debug.LogError("golfFlag n'est pas assigné dans l'inspecteur.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Golf collision enemy");
            // Calculer la force de la collision
            Vector3 collisionForce = collision.impulse / Time.fixedDeltaTime;

            // Appliquer une force proportionnelle à l'impact, ajustée par le multiplicateur
            rb.AddForce(collisionForce * forceMultiplier, ForceMode.Impulse);
        }

        if (collision.gameObject.name == "hole")
        {
            // Vérifier si le Renderer de golf_flag existe
            if (golfFlagRenderer != null)
            {
                // Changer la couleur de l'objet "golf_flag" en une couleur spécifique
                golfFlagRenderer.material.color = Color.green;  // Par exemple, changer la couleur en rouge
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
            // Vérifier si le Renderer de golf_flag existe
            if (golfFlagRenderer != null)
            {
                // Changer la couleur de l'objet "golf_flag" en une couleur spécifique
                golfFlagRenderer.material.color = Color.green;  // Par exemple, changer la couleur en rouge
            }
            else
            {
                Debug.LogError("Le Renderer de golfFlag est introuvable.");
            }
        }
    }
}
