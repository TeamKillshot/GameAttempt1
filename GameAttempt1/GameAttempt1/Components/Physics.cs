using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAttempt1.Components
{
    public class Physics : Component
    {
        public Body Body { get; set; }
        public bool IsStatic { get; set; }

        public Component Owner;

        public Physics(string id, bool isStatic)
        {
            this.ID = id;
            this.Enabled = true;
            this.IsStatic = isStatic;
        }

        public Physics(string id, bool isStatic, Body _body)
        {
            this.ID = id;
            this.Enabled = true;
            this.IsStatic = isStatic;
            Body = _body;
        }

        public override void Update(float delta)
        {
            if (Enabled)
            {
                Owner.Position = Body.Position;
            }
            base.Update(delta);
        }
    }
}
