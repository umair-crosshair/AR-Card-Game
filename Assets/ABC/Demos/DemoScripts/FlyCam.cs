
using UnityEngine;
/// <summary>
/// WASD: Movement
/// Space: Climb Up
/// E:Drop Down
/// Shift: Move Faster
/// Control: Move Slower
/// </summary>
public class SpectatorCam : MonoBehaviour {

        public float cameraSensitivity = 90;
        public float climbSpeed = 4;
        public float normalMoveSpeed = 10;

        public float slowMoveFactor = 0.25f;
        public float fastMoveFactor = 3;
        private float rotationX = 0.0f;
        private float rotationY = 0.0f;

        private void Move() {
            if ( Input.GetKey(KeyCode.LeftShift) ||  Input.GetKey(KeyCode.RightShift)) {

                transform.position += transform.forward * (normalMoveSpeed * fastMoveFactor) *  Input.GetAxis("Vertical") * Time.deltaTime;
                transform.position += transform.right * (normalMoveSpeed * fastMoveFactor) *  Input.GetAxis("Horizontal") * Time.deltaTime;

            } else if ( Input.GetKey(KeyCode.LeftControl) ||  Input.GetKey(KeyCode.RightControl)) {

                transform.position += transform.forward * (normalMoveSpeed * slowMoveFactor) *  Input.GetAxis("Vertical") * Time.deltaTime;
                transform.position += transform.right * (normalMoveSpeed * slowMoveFactor) *  Input.GetAxis("Horizontal") * Time.deltaTime;

            } else {

                transform.position += transform.forward * normalMoveSpeed *  Input.GetAxis("Vertical") * Time.deltaTime;
                transform.position += transform.right * normalMoveSpeed *  Input.GetAxis("Horizontal") * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Space)) { transform.position += transform.up * climbSpeed * Time.deltaTime; }
            if (Input.GetKey(KeyCode.E)) { transform.position -= transform.up * climbSpeed * Time.deltaTime; }
        }

        void Start() {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update() {
            this.Move();
        }
    }