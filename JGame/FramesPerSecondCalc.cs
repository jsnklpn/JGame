using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JGame
{
    public class FramesPerSecondCalc
    {
        RevolvingDoorTimer _stopwatch;

        bool _smooth;
        int _lastDisplayTick;
        string _lastDisplayedFps;

        public bool Smooth { get { return _smooth; } set { _smooth = value; } }

        public string Fps 
        { 
            get 
            {
                if (_smooth && (Environment.TickCount - _lastDisplayTick < 500))
                    return _lastDisplayedFps;

                _lastDisplayTick = Environment.TickCount;
                return (_lastDisplayedFps = String.Format("{0:0.#}", GetFps()));
            } 
        }

        public FramesPerSecondCalc(bool smooth)
        {
            _stopwatch = new RevolvingDoorTimer(1024);
            _lastDisplayedFps = "";
            _lastDisplayTick = 0;
            _smooth = smooth;
        }

        private float GetFps()
        {
            float averageDelta = _stopwatch.AverageDelta();
            if (averageDelta != 0f)
                return ((1f / averageDelta) * 1000f);
            else
                return 0f;
        }

        public void DrawFrame()
        {
            _stopwatch.AddTick(Environment.TickCount);
        }
    }

    public class RevolvingDoorTimer
    {
        private int[] _items;
        private int _pointer;
        private bool _filled;
        private int _itemsAdded;

        public RevolvingDoorTimer(int maxCapacity)
        {
            _itemsAdded = 0;
            _filled = false;
            _pointer = 0;
            _items = new int[maxCapacity];
        }

        public void AddTick(int tickToAdd)
        {
            _items[_pointer] = tickToAdd;

            if (!_filled) 
                _itemsAdded++;

            _pointer++;
            if (_pointer == _items.Length)
            {
                _filled = true;
                _pointer = 0;
            }
        }

        public float AverageDelta()
        {
            if (!_filled)
            {
                if (_itemsAdded < 2)
                    return 0f;
                else
                {
                    // Get average of items currently there
                    int d = 0;
                    int td = _itemsAdded - 1;
                    for (int i = 1; i < _itemsAdded; i++)
                    {
                        d += (_items[i] - _items[i - 1]);
                    }

                    return ((float)d / (float)td);
                }
            }

            int totalDeltas = _items.Length - 1;
            int deltas = 0;

            int tmpPtr = (_pointer + 1) % _items.Length;
            while (tmpPtr != _pointer)
            {
                // compute delta
                int previous = (tmpPtr == 0) ? (_items.Length - 1) : (tmpPtr - 1);
                deltas += (_items[tmpPtr] - _items[previous]);

                tmpPtr = (tmpPtr + 1) % _items.Length;
            }

            return ((float)deltas / (float)totalDeltas);
        }
    }
}
