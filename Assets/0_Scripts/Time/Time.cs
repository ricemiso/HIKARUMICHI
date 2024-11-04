using Cysharp.Text;
using System;
using UnityEngine;

namespace Common
{
    /// <summary>
    /// ���Ԃ̃I�u�W�F�N�g
    /// </summary>
    public class Time
    {
        private const string FORMAT = "{0}:{1}:{2}";

        private float _second;
        public float Second => _second;

        private float _minute;
        private float _sec;
        private float _mSecond;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="second"> �P��(�b)�A�����_�ȉ����~���b </param>
        public Time(float second)
        {
            SetTime(second);
        }

        private void SetTime(float second)
        {
            _second = second < 0 ? 0 : second;


            _minute = (int)_second / 60;
            _sec = (int)_second % 60;
            var mSecoundStr = (_second - (_minute * 60) - _sec).ToString("f2");
            _mSecond = float.Parse(mSecoundStr) * 100;
        }

        /// <summary>
        /// UI�ɕ\������`���ŏo��
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ZString.Format(FORMAT, _minute, _sec, _mSecond);
        }
    }
}
