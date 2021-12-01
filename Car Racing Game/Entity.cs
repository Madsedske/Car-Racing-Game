using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Racing_Game
{
    
    public abstract class Entity : Sprite, IDisposable
    {
        public Map map;
        
        public Entity(string filePath) : base(new Texture(filePath))
        {
        }
        public abstract void Update();
        
    }
}
