using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomizeButtons : MonoBehaviour
{

    public Button btnOne;
    public Button btnTwo;
    public Button btnThree;
    public Button btnFour;

    public Vector3 position1 = new Vector3(-260f, 80f, 0f);
    public Vector3 position2 = new Vector3(260f, 80f, 0f);
    public Vector3 position3 = new Vector3(-260f, -80f, 0f);
    public Vector3 position4 = new Vector3(260f, -80f, 0f);

    public void MoveButtons()
    {
        int buttonPos = Random.Range(0, 23);

        switch (buttonPos)
        {
            case 0:
                btnOne.transform.localPosition = position1;
                btnTwo.transform.localPosition = position2;
                btnThree.transform.localPosition = position3;
                btnFour.transform.localPosition = position4;
                break;
            case 1:
                btnOne.transform.localPosition = position1;
                btnTwo.transform.localPosition = position2;
                btnThree.transform.localPosition = position4;
                btnFour.transform.localPosition = position3;
                break;
            case 2:
                btnOne.transform.localPosition = position1;
                btnTwo.transform.localPosition = position3;
                btnThree.transform.localPosition = position4;
                btnFour.transform.localPosition = position2;
                break;
            case 3:
                btnOne.transform.localPosition = position1;
                btnTwo.transform.localPosition = position3;
                btnThree.transform.localPosition = position2;
                btnFour.transform.localPosition = position4;
                break;
            case 4:
                btnOne.transform.localPosition = position1;
                btnTwo.transform.localPosition = position4;
                btnThree.transform.localPosition = position2;
                btnFour.transform.localPosition = position3;
                break;
            case 5:
                btnOne.transform.localPosition = position1;
                btnTwo.transform.localPosition = position4;
                btnThree.transform.localPosition = position3;
                btnFour.transform.localPosition = position2;
                break;
            case 6:
                btnOne.transform.localPosition = position2;
                btnTwo.transform.localPosition = position1;
                btnThree.transform.localPosition = position3;
                btnFour.transform.localPosition = position4;
                break;
            case 7:
                btnOne.transform.localPosition = position2;
                btnTwo.transform.localPosition = position1;
                btnThree.transform.localPosition = position4;
                btnFour.transform.localPosition = position3;
                break;
            case 8:
                btnOne.transform.localPosition = position2;
                btnTwo.transform.localPosition = position3;
                btnThree.transform.localPosition = position1;
                btnFour.transform.localPosition = position4;
                break;
            case 9:
                btnOne.transform.localPosition = position2;
                btnTwo.transform.localPosition = position3;
                btnThree.transform.localPosition = position4;
                btnFour.transform.localPosition = position1;
                break;
            case 10:
                btnOne.transform.localPosition = position2;
                btnTwo.transform.localPosition = position4;
                btnThree.transform.localPosition = position3;
                btnFour.transform.localPosition = position1;
                break;
            case 11:
                btnOne.transform.localPosition = position2;
                btnTwo.transform.localPosition = position4;
                btnThree.transform.localPosition = position1;
                btnFour.transform.localPosition = position3;
                break;
            case 12:
                btnOne.transform.localPosition = position3;
                btnTwo.transform.localPosition = position1;
                btnThree.transform.localPosition = position2;
                btnFour.transform.localPosition = position4;
                break;
            case 13:
                btnOne.transform.localPosition = position3;
                btnTwo.transform.localPosition = position1;
                btnThree.transform.localPosition = position4;
                btnFour.transform.localPosition = position2;
                break;
            case 14:
                btnOne.transform.localPosition = position3;
                btnTwo.transform.localPosition = position2;
                btnThree.transform.localPosition = position1;
                btnFour.transform.localPosition = position4;
                break;
            case 15:
                btnOne.transform.localPosition = position3;
                btnTwo.transform.localPosition = position2;
                btnThree.transform.localPosition = position4;
                btnFour.transform.localPosition = position1;
                break;
            case 16:
                btnOne.transform.localPosition = position3;
                btnTwo.transform.localPosition = position4;
                btnThree.transform.localPosition = position1;
                btnFour.transform.localPosition = position2;
                break;
            case 17:
                btnOne.transform.localPosition = position3;
                btnTwo.transform.localPosition = position4;
                btnThree.transform.localPosition = position2;
                btnFour.transform.localPosition = position1;
                break;
            case 18:
                btnOne.transform.localPosition = position4;
                btnTwo.transform.localPosition = position1;
                btnThree.transform.localPosition = position2;
                btnFour.transform.localPosition = position3;
                break;
            case 19:
                btnOne.transform.localPosition = position4;
                btnTwo.transform.localPosition = position1;
                btnThree.transform.localPosition = position3;
                btnFour.transform.localPosition = position2;
                break;
            case 20:
                btnOne.transform.localPosition = position4;
                btnTwo.transform.localPosition = position2;
                btnThree.transform.localPosition = position1;
                btnFour.transform.localPosition = position3;
                break;
            case 21:
                btnOne.transform.localPosition = position4;
                btnTwo.transform.localPosition = position2;
                btnThree.transform.localPosition = position3;
                btnFour.transform.localPosition = position1;
                break;
            case 22:
                btnOne.transform.localPosition = position4;
                btnTwo.transform.localPosition = position3;
                btnThree.transform.localPosition = position1;
                btnFour.transform.localPosition = position2;
                break;
            case 23:
                btnOne.transform.localPosition = position4;
                btnTwo.transform.localPosition = position3;
                btnThree.transform.localPosition = position2;
                btnFour.transform.localPosition = position1;
                break;
        }
    }

}
