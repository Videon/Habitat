using UnityEngine;
using UnityEngine.EventSystems;

public class PointerSelector : MonoBehaviour, IPointerEnterHandler
{
    // Start is called before the first frame update

    public GameObject MovePointer;
  


    // Update is called once per frame

     public void  OnPointerEnter(PointerEventData pointerEventData) {

       if (gameObject.name == "StartGame" ) {
            MovePointer.GetComponent<Animator>().SetTrigger("GoUp");
            Debug.Log("Start");

        }
       
       else if (gameObject.name == "Quit") {
            MovePointer.GetComponent<Animator>().SetTrigger("GoDown");
            Debug.Log("Quit");

        }


        
    }

 
}