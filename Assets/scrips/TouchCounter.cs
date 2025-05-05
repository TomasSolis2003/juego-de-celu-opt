using UnityEngine;



public class TouchCounter : MonoBehaviour

{

    private int tapCount = 0;



    void Update()

    {

        if (Input.touchCount > 0)

        {

            Touch touch = Input.GetTouch(0);



            if (touch.phase == TouchPhase.Began)

            {

                tapCount++;

                Debug.Log("Cantidad de toques en pantalla: " + tapCount);

            }

        }

    }

}