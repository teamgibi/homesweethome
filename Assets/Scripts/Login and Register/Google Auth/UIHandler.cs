using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {
    public void OnClickGetGoogleCode() {
        GoogleAuthenticator.SignInWithGoogle();
    }
}
