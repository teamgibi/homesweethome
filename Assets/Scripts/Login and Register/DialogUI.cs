using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace EasyUI.Dialogs {

    public class Dialog {
        public string DialogText;
    }

    public class DialogUI : MonoBehaviour {

        [SerializeField] GameObject canvas;
        [SerializeField] Text dialogUIText;

        Dialog dialog = new Dialog();
        public static DialogUI Instance;

        void Awake() {
            Instance = this;
            canvas.SetActive(false);
        }

        public DialogUI SetMessage(string message) {
            dialog.DialogText = message;
            return Instance;
        }

        public void Show(){
            StartCoroutine(WaitBeforeShow());
        }

        private IEnumerator WaitBeforeShow(){
            dialogUIText.text = dialog.DialogText;
            canvas.SetActive(true);
            yield return new WaitForSeconds(3);
            canvas.SetActive(false);
            dialog = new Dialog();
        }
        
    }
}