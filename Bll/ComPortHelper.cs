using System.Threading;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Bll
{
    public class ComPortHelper
    {
        private Computer _pc;
        private System.Timers.Timer _tiComPortChange;
        private Mutex _mutex;
        private int _count;
        public delegate void ComPortCountChangeHandler(List<string> portnames);
        public event ComPortCountChangeHandler CountChange;

        public ComPortHelper()
        {

        }

        public ComPortHelper(int delaytime)
        {
            this.DelayTime = delaytime;
        }

        private int _delaytime = 250;

        public int DelayTime
        {
            get { return _delaytime; }
            set
            {
                if (_delaytime == value) return;
                _delaytime = value;
                if (_tiComPortChange != null)
                {
                    _tiComPortChange.Interval = _delaytime;
                }
            }
        }


        private void OnCountChange(List<string> portnames)
        {
            CountChange?.Invoke(portnames);
        }

        public int Count
        {
            get
            {
                if (_pc == null) _pc = new Computer();
                return _pc.Ports.SerialPortNames.Count;
            }
        }

        public List<string> PortNames
        {
            get
            {
                if (_pc == null) _pc = new Computer();
                List<string> listportname = new List<string>();
                listportname.AddRange(_pc.Ports.SerialPortNames);
                return listportname;
            }
        }

        public void Start()
        {
            if (_tiComPortChange == null)
            {
                _pc = new Computer();
                _mutex = new Mutex();
                _tiComPortChange = new System.Timers.Timer(DelayTime) {AutoReset = true};
                _tiComPortChange.Elapsed += _tiComPortChange_Elapsed;
            }
            _tiComPortChange.Start();
        }

        void _tiComPortChange_Elapsed(object sender, ElapsedEventArgs e)
        {
            _mutex.WaitOne();
            if (Count != _count)
            {
                _count = Count;
                List<string> listportname = new List<string>();
                listportname.AddRange(_pc.Ports.SerialPortNames);
                OnCountChange(listportname);
            }
            _mutex.ReleaseMutex();
        }

        public void Stop()
        {
            _tiComPortChange?.Stop();
        }
    }
}
