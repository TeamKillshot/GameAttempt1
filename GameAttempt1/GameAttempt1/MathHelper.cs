using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAttempt1
{
    public static class MathHelper
    {
        //Vector2
        public static Vector2 Convert(FarseerPhysics.Fluids.Vec2 FarseerVector2)
        {
            Vector2 toReturn;
            toReturn.X = FarseerVector2.X;
            toReturn.Y = FarseerVector2.Y;
            return toReturn;
        }

        public static void Convert(ref FarseerPhysics.Fluids.Vector2 FarseerVector, out Vector2 xnaVector)
        {
            xnaVector.X = FarseerVector.X;
            xnaVector.Y = FarseerVector.Y;
        }

        public static FarseerPhysics.Fluids.Vector2 Convert(Vector2 xnaVector)
        {
            FarseerPhysics.Fluids.Vector2 toReturn;
            toReturn.X = xnaVector.X;
            toReturn.Y = xnaVector.Y;
            return toReturn;
        }

        public static void Convert(ref Vector2 xnaVector, out FarseerPhysics.Fluids.Vector2 farseerVector)
        {
            farseerVector.X = xnaVector.X;
            farseerVector.Y = xnaVector.Y;
        }

    }
}
