using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DepDot
{
    public enum Direction
    {
        TO,
        FROM,
        INTER
    };

    public class Dependency
    {
        public Direction Direction;

        public int Weight;

        public string Target;
    }
}
