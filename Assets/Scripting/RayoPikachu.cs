using System.Collections;
using UnityEngine;
using DigitalRuby.LightningBolt;

// Se coloca en el MISMO objeto de Pikachu que ya tiene el script de salto.
// No reemplaza el salto: lo complementa lanzando un rayo hacia Charizard.
public class RayoPikachu : MonoBehaviour
{
    [Header("Referencias (arrastrar desde la Hierarchy)")]
    [Tooltip("El objeto RayoPikachu (prefab del Asset Store)")]
    public LightningBoltScript rayo;

    [Tooltip("Punto vacío en la cabeza de Pikachu desde donde sale el rayo")]
    public Transform origenRayo;

    [Tooltip("El modelo de Charizard que tiene el Collider")]
    public Transform charizard;

    [Tooltip("Opcional: punto vacío en el pecho de Charizard donde impacta el rayo")]
    public Transform puntoImpacto;

    [Header("Ajustes del ataque")]
    [Range(0f, 1f)] public float retraso = 0.2f;      // espera antes del rayo (para que salte primero)
    [Range(0.1f, 3f)] public float duracion = 1.0f;    // cuánto tiempo dura el ataque
    [Range(0.02f, 0.2f)] public float intervalo = 0.05f; // cada cuánto se redibuja el rayo
    [Range(0.5f, 5f)] public float enfriamiento = 2.0f; // tiempo mínimo entre ataques

    private bool puedeAtacar = true;

    void Awake()
    {
        // El rayo NO debe dispararse solo: solo cuando lo llamemos desde aquí
        if (rayo != null)
        {
            rayo.ManualMode = true;
        }
    }

    void Start()
    {
        if (rayo == null || charizard == null)
        {
            Debug.LogWarning("RayoPikachu: faltan referencias en el Inspector (Rayo o Charizard).");
            return;
        }

        Transform origen = (origenRayo != null) ? origenRayo : transform;
        Transform destino = (puntoImpacto != null) ? puntoImpacto : charizard;

        rayo.StartObject = origen.gameObject;
        rayo.EndObject = destino.gameObject;
        rayo.StartPosition = Vector3.zero;
        rayo.EndPosition = Vector3.zero;
    }

    // Funciona tanto si la colisión es con "Is Trigger" como si es colisión física
    void OnTriggerEnter(Collider otro)
    {
        RevisarChoque(otro.transform);
    }

    void OnCollisionEnter(Collision choque)
    {
        RevisarChoque(choque.transform);
    }

    void RevisarChoque(Transform otro)
    {
        if (!puedeAtacar || rayo == null || charizard == null)
        {
            return;
        }

        // Compara también por jerarquia raiz: el collider que golpea puede ser el modelo real
        // o el "Occlusion Object" (u otro hijo) del mismo Image Target de Charizard.
        bool esCharizard = (otro == charizard) || otro.IsChildOf(charizard) || (charizard != null && otro.root == charizard.root);

        if (esCharizard)
        {
            Debug.Log("⚡ ¡Pikachu usó Impactrueno contra " + otro.name + "!");
            StartCoroutine(LanzarRayo());
        }
    }

    IEnumerator LanzarRayo()
    {
        puedeAtacar = false;

        yield return new WaitForSeconds(retraso);

        float tiempo = 0f;
        while (tiempo < duracion)
        {
            rayo.Trigger();                          // dibuja un rayo nuevo (forma aleatoria)
            yield return new WaitForSeconds(intervalo);
            tiempo += intervalo;
        }

        yield return new WaitForSeconds(enfriamiento);
        puedeAtacar = true;
    }

    void OnDisable()
    {
        // Si el objeto se desactiva a mitad del ataque, se reinicia el estado
        StopAllCoroutines();
        puedeAtacar = true;
    }
}