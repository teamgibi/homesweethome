using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class TabInputFieldForLogin : MonoBehaviour {
    
    public InputField email;
    public InputField password;
    public int selectedInput;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)){
            selectedInput++;
            if (selectedInput > 1){
                selectedInput = 0;
            }
            SelectInputField();
        }

        void SelectInputField(){
            switch(selectedInput){
                case 0:
                    email.Select();
                    break;
                case 1:
                    password.Select();
                    break;
            }
        }
    }
    
    public void EmailSelected() => selectedInput = 0;
    public void PasswordSelected() => selectedInput = 1;
}