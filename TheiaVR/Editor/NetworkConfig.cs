﻿namespace TheiaVR.Editor
{
    public class NetworkConfig
    {
        public NetworkConfig(int id, string ipAddress, int cloudPort, int skelPort, bool enableCloud, bool enableSkel)
        {
            this.Id = id;
            this.IpAddress = ipAddress;
            this.CloudPort = cloudPort;
            this.SkelPort = skelPort;
            this.EnableCloud = enableCloud;
            this.EnableSkel = enableSkel;
        }
        
        public int Id { get; set; }
        
        public string IpAddress { get; set; }

        public int CloudPort { get; set; }

        public int SkelPort { get; set; }

        public bool EnableCloud { get; set; }

        public bool EnableSkel { get; set; }
    }
}