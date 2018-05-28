﻿using TheiaVR.Helpers;
using TheiaVR.Graphics;
using TheiaVR.Controllers.Listeners;
using UnityEditor;

namespace TheiaVR.Controllers
{
    /**
     * Class allowing to listen UDP stream from the Kinect streamer
     */
    public class StreamController
    {
        private static StreamController instance = null;

        private UDPStreamListener skeleton;

        private UDPStreamListener cloud;

        private StreamController()
        {
            // Used to prevent public access
        }

        public static StreamController GetInstance()
        {
            if(instance == null)
            {
                instance = new StreamController();
            }
            return instance;
        }
        
        public void Start(bool aStartSkeleton, bool aStartCloud)
        {
                if (skeleton == null && aStartSkeleton)
                {
                    if (SkeletonRenderer.GetInstance() != null)
                    {
                        skeleton = new SkeletonListener();
                        skeleton.Start("127.0.0.1", EditorPrefs.GetInt("skelPort"));
                    }
                    else
                    {
                        Messages.LogError("SkeletonRenderer is not activated. Please associate it to a game component and try again.");
                    }
                }

            if (cloud == null && aStartCloud)
            {
                cloud = new CloudListener();
                cloud.Start("127.0.0.1", EditorPrefs.GetInt("cloudPort"));
            }
        }

        public void Stop()
        {
            if (skeleton != null && skeleton.IsActive())
            {
                skeleton.Stop();
                skeleton = null;
            }

            if (cloud != null && cloud.IsActive())
            {
                cloud.Stop();
                cloud = null;
            }
        }

        public bool IsActive()
        {
            return (skeleton != null && skeleton.IsActive()) || (cloud != null && cloud.IsActive());
        }
    }
}
