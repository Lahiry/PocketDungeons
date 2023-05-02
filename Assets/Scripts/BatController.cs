// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BatController : MonoBehaviour
// {
//     public Collider2D batColliderRight;
//     public Collider2D batColliderLeft;
//     public Collider2D batColliderFront;
//     public Collider2D batColliderBack;

//     void Start()
//     {
//         base.Start();

//         batColliderRight.enabled = false;
//         batColliderLeft.enabled = false;
//         batColliderFront.enabled = false;
//         batColliderBack.enabled = false;
//     }

//     void Update()
//     {   
//         base.Update();

//         if (isAttacking)
//         {
//             if (GetComponent<Animator>().GetBool("FaceRight"))
//             {
//                 batColliderRight.enabled = true;
//             }
//             else if (GetComponent<Animator>().GetBool("FaceLeft"))
//             {
//                 batColliderLeft.enabled = true;
//             }
//             else if (GetComponent<Animator>().GetBool("FaceFront"))
//             {
//                 batColliderFront.enabled = true;
//             }
//             else if (GetComponent<Animator>().GetBool("FaceBack"))
//             {
//                 batColliderBack.enabled = true;
//             }

//             Invoke("DeactivateBatCollider", 0.1f);
//         }
//         else
//         {
//             GetComponent<Animator>().SetBool("Atk", false);
//         }
        
//     }

//     private void DeactivateBatCollider()
//     {
//         batColliderRight.enabled = false;
//         batColliderLeft.enabled = false;
//         batColliderFront.enabled = false;
//         batColliderBack.enabled = false;
//     }
// }
