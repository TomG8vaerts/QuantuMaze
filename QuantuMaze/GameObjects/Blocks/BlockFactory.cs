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
                newBlock = new Tile(x, y);
            }
            if (type == 2)
            {
                newBlock = new Wall(x, y);
            }
            if (type == 3)
            {

            }
            return newBlock;
        }


    }
}
