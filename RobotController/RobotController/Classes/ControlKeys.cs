using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Classes
{
    public class ControlKeys
    {
        char keyUp;
        char keyDown;
        char keyLeft;
        char keyRight;
        char keyTerm;

        public char KeyUp
        {
            get { return keyUp; }
            set { keyUp = value; }
        }

        public char KeyDown
        {
            get { return keyDown; }
            set { keyDown = value; }
        }

        public char KeyLeft
        {
            get { return keyLeft; }
            set { keyLeft = value; }
        }

        public char KeyRight
        {
            get { return keyRight; }
            set { keyRight = value; }
        }

        public char KeyTerm
        {
            get { return keyTerm; }
            set { keyTerm = value; }
        }
    }
}
