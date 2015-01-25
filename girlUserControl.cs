using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace UnitySampleAssets._2D
{

    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class girlUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D character;
        private Animator anim; // Reference to the player's animator component.
        private bool jump;
        public bool isActive = true;

        private float mantleTime = 2.0f;
        private float mantleProgress = 0.0f;


        private void Awake()
        {
            anim = GetComponent<Animator>();
            character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            if (!jump)
                // Read the jump input in Update so button presses aren't missed.
                jump = CrossPlatformInputManager.GetButtonDown("Jump");
            if (isManteling)
            {
                bezierTime += Time.deltaTime;
                if (bezierTime >= 1)
                {
                    bezierTime = 0;
                    isManteling = false;
                    return;
                }

                curve.x = (((1 - bezierTime) * (1 - bezierTime)) * startPoint.x) + (2 * bezierTime * (1 - bezierTime) * controlPoint.x) + ((bezierTime * bezierTime) * endPoint.x);
                curve.y = (((1 - bezierTime) * (1 - bezierTime)) * startPoint.y) + (2 * bezierTime * (1 - bezierTime) * controlPoint.y) + ((bezierTime * bezierTime) * endPoint.y);
                transform.position = new Vector3(curve.x, curve.y, 0);
            }
        }

        private void FixedUpdate()
        {
            if (isActive)
            {
                /*if (isManteling)
                {
                    mantleProgress += (Time.deltaTime / mantleTime); 
                    Renderer rend = GetComponent<Renderer>();
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + rend.bounds.extents.x, transform.position.y, transform.position.z), mantleProgress);
                    if (mantleProgress > 1)
                    {
                        isManteling = false;
                    }
                }*/

                // Read the inputs.
                bool crouch = Input.GetKey(KeyCode.LeftControl);
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                float v = CrossPlatformInputManager.GetAxis("Vertical");
                // Pass all parameters to the character control script.
                character.Move(h, v, crouch, jump);
                jump = false;

            }

        }

        //test code for lerping up branch
        public Vector3 startPoint;
        public Vector3 controlPoint;
        public Vector3 endPoint;
        public Vector3 curve;
        public float speed = 1.0f;
        private float bezierTime;
        public Transform target;
        public float smooth = 5.0f;
        private bool isManteling;


        public float mantelControlX = -5;
        public float mantelControlY = 15;

        void OnTriggerEnter2D(Collider2D collider)
        {
            //Debug.Log(collider.transform.ToString());

            
            if (!isManteling)
            {
                if (collider.gameObject.tag == "mantelPoint")
                {
                    startPoint = transform.position;
                    endPoint = new Vector3(collider.transform.position.x + mantelControlX, (collider.transform.position.y + mantelControlY) * -1, 0);
                    controlPoint = new Vector3(startPoint.x, endPoint.y, 0);



                    anim.SetTrigger("mantleTrigger");

                    //Renderer rend = GetComponent<Renderer>();
                    //transform.position = new Vector3(transform.position.x + rend.bounds.extents.x,
                    //   rend.bounds.extents.y * .5f,
                    //    transform.position.z);


                    ////playerBottomPos = branch.position;
                    //Vector3 sub = branchTopPos - playerBottomPos;
                    //transform.Translate(sub.x, sub.y, sub.z, null);
                    isManteling = true;
                }
            }


        }

        public void SwapPlayer()
        {
            isActive = !isActive;
        }
    }
}