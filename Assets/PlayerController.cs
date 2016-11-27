using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

  public float speed;
  public Text countText;

  private int count;
  private Rigidbody rb;

	// Use this for initialization
	void Start () {
    count = 0;
    countText.text = "Count test: " + count.ToString ();
    rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  // FixedUpdate is called before physics calculations
  void FixedUpdate () {
    float moveHorizontal = Input.GetAxis ("Horizontal");
    float moveVertical = Input.GetAxis ("Vertical");

    Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

    rb.AddForce (movement * speed);
  }

  void OnTriggerEnter (Collider other) {
    if (other.gameObject.CompareTag ("Pickup")) {
      other.gameObject.SetActive (false);
      count += 1;
      countText.text = "Count test: " + count.ToString ();
    }
  }
}
