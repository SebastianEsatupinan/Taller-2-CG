using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sebastian Estupiñan Sanchez
public class Movimientodeljugador : MonoBehaviour
{
    // Variables modificables desde el inspector
    public float JumpForce;
    public int JumpMax;
    public float velocidad;
    public LayerMask CapaSuelo;
    public GameObject BulletPrefab;
    public float tiempoDeEsperaEntreDisparos = 0.5f; // Tiempo de espera entre disparos (ajusta según tus necesidades)

    // Variables de uso privado
    private Rigidbody2D RG2D;
    private CapsuleCollider2D Capsule;
    private float Horizontal;
    private int SaltosRestantes;
    private Animator Animator;
    private float tiempoUltimoDisparo = 0.0f;

    void Start()
    {
        RG2D = GetComponent<Rigidbody2D>();
        Capsule = GetComponent<CapsuleCollider2D>();
        SaltosRestantes = JumpMax;
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Llamado de métodos necesarios
        Moverse();
        Jump();
        Shoot();
    }

    private void Moverse()
    {
        // Función para moverse de izquierda a derecha
        Horizontal = Input.GetAxisRaw("Horizontal") * velocidad;

        // Voltea el personaje en la dirección adecuada
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Actualiza el estado de la animación
        Animator.SetBool("EstaCorriendo", Horizontal != 0.0f);
    }

    private bool EstaEnSuelo()
    {
        // Detecta si está en el suelo o no
        RaycastHit2D raycastHit = Physics2D.CapsuleCast(
            Capsule.bounds.center,
            Capsule.bounds.size,
            CapsuleDirection2D.Vertical,
            0f,
            Vector2.down,
            0.02f,
            CapaSuelo);

        return raycastHit.collider != null;
    }

    private void Jump()
    {
        // Función para saltar
        if (EstaEnSuelo())
        {
            SaltosRestantes = JumpMax;
        }

        // Permite saltar si aún quedan saltos restantes y se presiona la tecla correspondiente
        if (Input.GetKeyDown(KeyCode.W) && SaltosRestantes > 0)
        {
            Animator.SetTrigger("aSaltado");
            SaltosRestantes--;
            RG2D.velocity = new Vector2(RG2D.velocity.x, 0f);
            RG2D.AddForce(Vector2.up * JumpForce);
        }
    }

    private void Shoot()
    {
        // Método para disparar
        if (Time.time - tiempoUltimoDisparo >= tiempoDeEsperaEntreDisparos)
        {
            // Permite disparar si ha pasado el tiempo de espera y se presiona la tecla correspondiente
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Animator.SetTrigger("aDisparado");
                Vector3 direccionBala = transform.localScale.x == 1.0f ? Vector3.right : Vector3.left;
                GameObject bullet = Instantiate(BulletPrefab, transform.position + direccionBala * 0.2f, Quaternion.identity);

                // Voltea la escala de la bala si el personaje mira hacia la izquierda
                if (transform.localScale.x == -1.0f)
                {
                    Vector3 newScale = bullet.transform.localScale;
                    newScale.x *= -1; // Invierte la escala en el eje X
                    bullet.transform.localScale = newScale;
                }

                bullet.GetComponent<Disparo>().setDirection(direccionBala);

                // Actualiza el tiempo del último disparo
                tiempoUltimoDisparo = Time.time;
            }
        }
    }

    private void FixedUpdate()
    {
        // Aplica la velocidad al personaje en el eje horizontal
        RG2D.velocity = new Vector2(Horizontal, RG2D.velocity.y);
    }
}
