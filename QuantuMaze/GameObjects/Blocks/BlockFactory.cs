namespace QuantuMaze.GameObjects.Blocks
{
    internal class BlockFactory
    {
        public static Block CreateBlock(
    int type, int x, int y)
        {
            Block newBlock = null;
            if (type == 0)
            {
                newBlock = new Empty(x, y);
            }
            if (type == 1)
            {
                newBlock = new Wall(x, y);
            }
            if (type == 2)
            {
                newBlock = new Tile(x, y);
            }
            if (type == 3)
            {
                newBlock= new LeftWallTile(x, y);
            }
            if (type==4)
            {
                newBlock = new RightWallTile(x, y);
            }
            if (type==5)
            {
                newBlock = new DoubleWallTile(x, y);
            }
            return newBlock;
        }


    }
}
