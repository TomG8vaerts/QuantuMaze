using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.Levels
{
    public abstract class LevelContent
    {
        protected ContentManager content;
        public LevelContent(ContentManager content)
        {
            this.content = content;
        }
    }
}
