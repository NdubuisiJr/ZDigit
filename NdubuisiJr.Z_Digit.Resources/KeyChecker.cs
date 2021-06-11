using System;

namespace NdubuisiJr.Z_Digit.Resources
{
    public class KeyChecker
    {

        public bool CheckDouble(int _key) {
            return ((_key >= 34 && _key <= 43) || _key == 144) || ((_key >= 74 && _key <= 83) || _key == 88);
        }

        public bool CheckInteger(int _key) {
            return (_key >= 34 && _key <= 43) || (_key >= 74 && _key <= 83);
        }
    }
}
