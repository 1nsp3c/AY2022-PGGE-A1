using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PGGE
{
    // The base class for all third-person camera controllers
    public abstract class TPCBase
    {
        protected Transform mCameraTransform;
        protected Transform mPlayerTransform;

        public Transform CameraTransform
        {
            get
            {
                return mCameraTransform;
            }
        }
        public Transform PlayerTransform
        {
            get
            {
                return mPlayerTransform;
            }
        }

        public TPCBase(Transform cameraTransform, Transform playerTransform)
        {
            mCameraTransform = cameraTransform;
            mPlayerTransform = playerTransform;
        }

        public Vector3 mPlayerOFfset;
        public void RepositionCamera()
        {
            //-------------------------------------------------------------------
            // Implement here.
            //-------------------------------------------------------------------
            //-------------------------------------------------------------------
            // Hints:
            //-------------------------------------------------------------------
            // check collision between camera and the player.
            // find the nearest collision point to the player
            // shift the camera position to the nearest intersected point
            //-------------------------------------------------------------------
            //Need the data from the point where the camera and wall collides
            RaycastHit hit;
            //Finding the offset of the player
            mPlayerOFfset = mPlayerTransform.position + new Vector3(0, 2, 0);
            //Sets an invisible line that constantly checks if the line collides with the layermask of the wall
            if (Physics.Linecast(mCameraTransform.position, mPlayerOFfset, out hit, LayerMask.GetMask("Wall")))
            {
                //Sets the cameras position to the point where the camera and wall collides
                mCameraTransform.position = hit.point;
            }
        }

        public abstract void Update();
    }
}
