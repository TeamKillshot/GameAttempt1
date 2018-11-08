using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAttempt1.Components
{
    public abstract class Component
    {
        public delegate void ObjectIDHandler(string ID);
        public string ID { get; set; }
        public bool Enabled { get; set; }
        public Vec2 Position { get; set; }


        //public GameObject Owner { get; set; }
        public event ObjectIDHandler OnDestroy;

        public Component()
        {
            ID = this.GetType().Name + Guid.NewGuid();
            Enabled = true;
        }

        public virtual void PostInitialize() { }

        public Component(string id) { ID = id; Enabled = true; }

        public virtual void Initialize() { }
        public virtual void Update(float delta) { }

        public virtual void Destroy()
        {
            if (OnDestroy != null)
                OnDestroy(ID);
        }
    }
}
