namespace CShapeNetPortScanApplication
{
    class PortList
    {
        private int start;
        private int stop;
        private int ports;

        public PortList(int starts, int stops)
        {
            start = starts;
            stop = stops;
            ports = start;
        }
        public int getPortNum()
        {
            return (stop - start)+1;
        }
        public int getCurrentProgress()
        {
            //return ((ports - start) + 1.0) / getPortNum()*100;
            //return (int)(ports * 100.0 / getPortNum());
            return (int)((ports-1-start+1) * 100.0 / getPortNum());
        }
        public int getCurrentPort() {
            return ports;
        }
        public bool MorePorts()
        {
            return (stop - ports) >= 0;
        }
        public int NextPort()
        {
            if (MorePorts())
            {
                return ports++;
            }
            return -1;
        }
    }
}