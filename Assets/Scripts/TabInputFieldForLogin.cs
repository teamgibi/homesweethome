using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class TabInputFieldForLogin : MonoBehaviour
{

    public InputField username; //0
    public InputField password; //1

    public int selectedInput;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            selectedInput--;
            if (selectedInput < 0){
                selectedInput = 1;
            }
            SelectInputField();
        }else if (Input.GetKeyDown(KeyCode.Tab)){
            selectedInput++;
            if (selectedInput > 1){
                selectedInput = 0;
            }
            SelectInputField();
        }

        void SelectInputField(){
            switch(selectedInput){
                case 0:
                    username.Select();
                    break;
                case 1:
                    password.Select();
                    break;
            }
        }
    }

    public void UsernameSelected() => selectedInput = 0;
    public void PasswordSelected() => selectedInput = 1;

}