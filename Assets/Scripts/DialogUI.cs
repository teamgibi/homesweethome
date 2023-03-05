using UnityEngine;
using UnityEngine.UI;

namespace EasyUI.Dialogs{

    public class Dialog{
        public string DialogText;
    }

    public class DialogUI : MonoBehaviour{
        [SerializeField] GameObject canvas;
        [SerializeField] Text dialogUIText;
        [SerializeField] Button closeUIButton;

        Dialog dialog = new Dialog();

        public static DialogUI Instance;

        void Awake(){
            Instance = this;
            closeUIButton.onClick.RemoveAllListeners();
            closeUIButton.onClick.AddListener(Hide);
            canvas.SetActive(false);
        }

        public DialogUI SetMessage(string message){
            dialog.DialogText = message;
            return Instance;
        }

        public void Show(){
            Debug.Log("show method");
            dialogUIText.text = dialog.DialogText;
            canvas.SetActive(true);
        }
        
        public void Hide(){
             canvas.SetActive(false);
             dialog = new Dialog();
        }
    }
}