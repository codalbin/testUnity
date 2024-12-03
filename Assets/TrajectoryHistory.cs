using System.Collections.Generic;
using UnityEngine;

public class TrajectoryHistory : MonoBehaviour
{
    public GameObject balle;            // La balle de golf
    public float dureeHistorique = 1f;  // Durée de l'historique de la trajectoire (en secondes)
    public LineRenderer lineRenderer;   // LineRenderer pour dessiner la trajectoire

    private List<Vector3> positionsBalle = new List<Vector3>();  // Liste pour stocker les positions passées
    private List<float> tempsPositions = new List<float>();     // Temps correspondant à chaque position

    void Start()
    {
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        // Initialisation du LineRenderer
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        // Ajouter la position actuelle de la balle
        positionsBalle.Add(balle.transform.position);
        tempsPositions.Add(Time.time);

        // Supprimer les positions trop anciennes
        float tempsActuel = Time.time;
        while (tempsPositions.Count > 0 && tempsActuel - tempsPositions[0] > dureeHistorique)
        {
            positionsBalle.RemoveAt(0);
            tempsPositions.RemoveAt(0);
        }

        // Mettre à jour le LineRenderer
        lineRenderer.positionCount = positionsBalle.Count;
        lineRenderer.SetPositions(positionsBalle.ToArray());

        // Appliquer les couleurs dégradées
        UpdateColors();
    }

    private void UpdateColors()
    {
        if (positionsBalle.Count > 1)
        {
            Gradient gradient = new Gradient();

            for (int i = 0; i < positionsBalle.Count; i++)
            {
                float t = i / (float)(positionsBalle.Count - 1); // Calculer la proportion (de 0 à 1)
            }
        }
    }
}
