using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorView : MonoBehaviour {
	public GameObject error_board;
	public Text error_text;

	void Start () {
		error_board.SetActive (false);
	}

	public void showError (string error) {
		showErrorBoard ();
		error_text.text = error;
	}

	public void hideErrorBoard () {
		error_board.SetActive (false);
	}

	private void showErrorBoard () {
		error_board.SetActive (true);
	}
}
