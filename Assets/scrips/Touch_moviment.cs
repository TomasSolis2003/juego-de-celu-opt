using UnityEngine;



public class TouchMove : MonoBehaviour

{

    public RectTransform objetoUI; // Asignar el objeto UI en el Inspector

    public float velocidad = 500f;



    private Vector2 destino;

    private RectTransform canvasRect;



    void Start()

    {

        canvasRect = objetoUI.GetComponentInParent<Canvas>().GetComponent<RectTransform>();

        destino = objetoUI.anchoredPosition;

    }



    void Update()

    {

        if (Input.touchCount > 0)

        {

            Touch toque = Input.GetTouch(0);



            if (toque.phase == TouchPhase.Began || toque.phase == TouchPhase.Moved)

            {

                Vector2 posPantalla = toque.position;

                Vector2 posLocal;



                // Convertir coordenadas de pantalla a coordenadas locales dentro del Canvas

                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, posPantalla, null, out posLocal);



                destino = posLocal;

            }

        }



        // Mover suavemente hacia el destino

        objetoUI.anchoredPosition = Vector2.MoveTowards(objetoUI.anchoredPosition, destino, velocidad * Time.deltaTime);

    }

}